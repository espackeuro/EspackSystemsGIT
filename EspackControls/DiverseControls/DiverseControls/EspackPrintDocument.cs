using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;
using AccesoDatos;
using AccesoDatosNet;

namespace DiverseControls
{
    public interface PrintableThing
    {
        object Item { get; set; }
        Font Font { get; set; }
        Brush Brush { get; set; }
        Graphics Graphics { get; set; }
        float Height { get; }
        float Width { get; }
        void Draw(float x, float y);
    }

    public class PrintableText : PrintableThing
    {
        private string _item;
        public object Item
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value.ToString();
            }
        }

        public Font Font { get; set; }
        public Brush Brush { get; set; }
        public Graphics Graphics { get; set; }
        public float Height
        {
            get
            {
                if (Graphics != null)
                    return Graphics.MeasureString(_item.Replace(' ', '@'), Font).Height;
                else return 0;
            }
        }
        public float Width
        {
            get
            {
                if (Graphics != null)
                    return Graphics.MeasureString(_item.Replace(' ', '@') + '@', Font).Width;
                else return 0;
            }
        }
        public PrintableText(string pText, Font pFont)
        {
            _item = pText;
            Font = pFont;
            Brush = new SolidBrush(Color.Black);
        }

        public void Draw(float x, float y)
        {
            if (Graphics != null)
            {
                Graphics.DrawString(_item, Font, Brush, x, y);
            }
        }
    }

    public class PrintableLine
    {
        public List<PrintableThing> Things { get; set; } = new List<PrintableThing>();
        //public float x { get; set; }
        //public float y { get; set; }

        public void Add(PrintableThing pThing)
        {
            Things.Add(pThing);
        }
        public PrintableThing this[int index]
        {
            get
            {
                return Things[index];
            }
        }
        public bool Empty { get; set; } = true;
        private Graphics _g;
        public Graphics Graphics
        {
            get
            {
                return _g;
            }
            set
            {
                _g = value;
                Things.ForEach(x => x.Graphics = value);
            }
        }
        public float Height
        {
            get
            {
                if (Things.Count != 0)
                    return Things.Max(x => x.Height);
                else return 0;
            }
        }
        public float Width
        {
            get
            {
                if (Things.Count != 0)
                    return Things.Sum(x => x.Width);
                else return 0;
            }
        }
        public bool Banding { get; set; } = false;
        public int LineNumber { get; set; }
    }

    public class PrintableLineList
    {
        private Graphics _g;
        public int LastPrintedLine { get; set; } = 0;
        public List<PrintableLine> Lines { get; set; } = new List<PrintableLine>();
        public Graphics Graphics
        {
            get
            {
                return _g;
            }
            set
            {
                _g = value;
                Lines.ForEach(x => x.Graphics = value);
            }
        }
        public float MaxHeight
        {
            get
            {
                if (Lines.Count != 0)
                    return Lines.Select(x => x.Height).Max();
                else
                    return 0;
            }
        }
        public float MaxWidth
        {
            get
            {
                if (Lines.Count != 0)
                    return Lines.Select(x => x.Width).Max();
                else
                    return 0;
            }
        }

    }
    public enum EnumDocumentParts { HEADER, BODY, FOOTER }

    public class EspackPrintDocument : PrintDocument
    {
        public const float TOP_MARGIN = 15F;
        public const float BOTTOM_MARGIN = 15F;
        public const float LEFT_MARGIN = 15F;
        public const float RIGHT_MARGIN = 15F;
        public const float FOOTER_TOP = 20F;

        public float BodyXOffset { get; set; } =0;
        public int PageCounter { get; set; } = 0;
        public float CurrentX { get; set; }
        public float CurrentY { get; set; }
        public PrintableLineList HeaderList { get; set; } = new PrintableLineList();
        public PrintableLineList BodyList { get; set; } = new PrintableLineList();
        public PrintableLineList FooterList { get; set; } = new PrintableLineList();
        public EnumDocumentParts CurrentZone { get; set; }
        public PrintableLine CurrentLine
        {
            get
            {
                switch (CurrentZone)
                {
                    case EnumDocumentParts.HEADER:
                        return HeaderList.Lines[CurrentLineIndex];
                    case EnumDocumentParts.BODY:
                        return BodyList.Lines[CurrentLineIndex];
                    case EnumDocumentParts.FOOTER:
                        return FooterList.Lines[CurrentLineIndex];
                    default:
                        return BodyList.Lines[CurrentLineIndex];
                }
            }
        }
        public int CurrentLineIndex { get; set; }

        public Font CurrentFont { get; set; }
        public Brush CurrentBrush { get; set; }

        public float XMin
        {
            get
            {
                return (DefaultPageSettings.PrintableArea.Left * 0.254F) + LEFT_MARGIN;
            }
        }
        public float XMax
        {
            get
            {
                return (DefaultPageSettings.PrintableArea.Right * 0.254F) - RIGHT_MARGIN;
            }
        }

        public float YMin
        {
            get
            {
                return (DefaultPageSettings.PrintableArea.Top * 0.254F) + TOP_MARGIN;
            }
        }

        public float YMax
        {
            get
            {
                //return (DefaultPageSettings.PrintableArea.Bottom * 0.254F) - RIGHT_MARGIN - FOOTER_TOP;
                return (DefaultPageSettings.PrintableArea.Bottom * 0.254F) - BOTTOM_MARGIN - FOOTER_TOP;
            }
        }
        public EspackPrintDocument() : base()
        {
            CurrentX = XMin;
            CurrentY = YMin;

            BodyList.Lines.Add(new PrintableLine());
            CurrentLineIndex = 0;
        }
        public void NewLine(bool pBanding = false, EnumDocumentParts pArea = EnumDocumentParts.BODY)
        {
            var _line = new PrintableLine() { Banding = pBanding, LineNumber = BodyList.Lines.Count };
            _line.Add(new PrintableText(" ", CurrentFont));
            switch (pArea)
            {
                case EnumDocumentParts.HEADER:
                    HeaderList.Lines.Add(_line);
                    CurrentLineIndex = HeaderList.Lines.Count - 1;
                    CurrentZone = EnumDocumentParts.HEADER;
                    break;
                case EnumDocumentParts.BODY:
                    BodyList.Lines.Add(_line);
                    CurrentLineIndex = BodyList.Lines.Count - 1;
                    CurrentZone = EnumDocumentParts.BODY;
                    break;
                case EnumDocumentParts.FOOTER:
                    FooterList.Lines.Add(_line);
                    CurrentLineIndex = FooterList.Lines.Count - 1;
                    CurrentZone = EnumDocumentParts.FOOTER;
                    break;
            }

        }
        public void Add(PrintableThing pThing)
        {
            if (CurrentLine.Empty)
            {
                CurrentLine.Things.RemoveAt(0);
                CurrentLine.Empty = false;
            }

            CurrentLine.Add(pThing);
            CurrentFont = pThing.Font;

        }

        public void ClearFooter()
        {
            FooterList.Lines.RemoveAll(item => true);
        }

        public void Add(string pText)
        {
            var _thing = new PrintableText(pText, CurrentFont);
            Add(_thing);
        }
        public void Add(string pText, Font pFont)
        {
            var _thing = new PrintableText(pText, pFont);
            Add(_thing);
            CurrentFont = pFont;
        }
        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            var g = e.Graphics;
            g.PageUnit = GraphicsUnit.Millimeter;
            float _x = XMin;
            float _y = YMin;

            //lets print the header
            HeaderList.Lines.ForEach(l =>
            {
                PrintDocumentLine(l, g, ref _y);
            });

            // lets print the lines
            if (BodyList.LastPrintedLine > 1)
                PrintDocumentLine(BodyList.Lines[1], g, ref _y, BodyXOffset); // column titles in following new pages

            while (_y <= YMax && BodyList.LastPrintedLine < BodyList.Lines.Count)
            {

                PrintDocumentLine(BodyList.Lines[BodyList.LastPrintedLine], g, ref _y, BodyXOffset);
                BodyList.LastPrintedLine++;
            }

            // lets print the footer
            _y = YMax;
            FooterList.Lines.ForEach(l =>
            {
                PrintDocumentLine(l, g, ref _y);
            });

            if (PageCounter != 0)
            {
                var _pCounter = new PrintableLine();
                _pCounter.Add(new PrintableText(string.Format("Page {0}", PageCounter), new Font("Courier New", 12, FontStyle.Bold)));
                PrintDocumentLine(_pCounter, g, ref _y);
                PageCounter++;
            }

                // are going to be more pages?
                e.HasMorePages = (BodyList.LastPrintedLine < BodyList.Lines.Count);

            base.OnPrintPage(e);
        }
        private void PrintDocumentLine(PrintableLine Line, Graphics g, ref float _y,float xOffset=0)
        {
            //var l = BodyList.Lines[BodyList.LastPrintedLine];
            Line.Graphics = g;
            var _x = XMin;
            var __y = _y;
            if (Line.Banding && (Line.LineNumber % 2 == 0))
                g.FillRectangle(new SolidBrush(Color.GhostWhite), XMin + xOffset, _y, Line.Width, Line.Height);
            Line.Things.ForEach(t =>
            {
                t.Draw(_x+xOffset, __y);
                _x += t.Width;
            });

            _y += Line.Height;
            _x = XMin;

        }
    }



    /* -----------------------------------------------------------------------------------------------
     *  NEW ESPACK PRINTING CLASSES
     * ----------------------------------------------------------------------------------------------- */

    public enum EnumDocumentZones { HEADER, BODY, FOOTER, NONE }
    public enum EnumZoneDocking { ALLOWED, RIGHTWARDS, DOWNWARDS, NONE }
    public enum EnumDrawingType { LINE, RECTANGLE, ELLIPSE }

    // Interface
    public interface IEspackPrintingItem
    {
        float X { get; set; }
        float Y { get; set; }
        bool EOL { get; set; }
        Graphics Graphics { get; set; }
        float Height { get; }
        float Width { get; }
        bool PrintMe { get; set;  }
        bool Persistent { get; set; }
        void Draw(Graphics pGraphics);
    }

    // Font class with millimeter units, brush and default values
    public class EspackFont
    {
        public Font Font;
        public Brush Brush;
        public EspackFont(string FontName = "Tahoma", float pSize = 10, FontStyle pStyle = FontStyle.Regular, Brush pBrush = null)
        {
            FontFamily pFamily;
            try
            {
                pFamily = new FontFamily(FontName);
            }
            catch (Exception)
            {
                pFamily = new FontFamily("Tahoma");
            }
            Font = new Font(pFamily, pSize, pStyle, GraphicsUnit.Millimeter);
            Brush = pBrush ?? new SolidBrush(Color.Black);
        }
    }

    // Image items class
    public class EspackPrintingDrawing : IEspackPrintingItem, IDisposable
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Graphics Graphics { get; set; }
        public bool EOL { get; set; }
        public bool PrintMe { get; set; }
        public bool Persistent { get; set; }
        public Shape Shape { get; set; }
        public Pen Pen { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public EnumDrawingType DrawingType { get; set; }
        
        public EspackPrintingDrawing(EnumDrawingType pDrawType , float pX, float pY, float pWidth, float pHeight,Pen pPen=null)
        {
            DrawingType = pDrawType;
            X = pX;
            Y = pY;
            Width = pWidth;
            Height = pHeight;
            Pen = pPen;
        }

        public void Draw(Graphics pGraphics)
        {
            if (pGraphics != null)
            {
                switch (DrawingType)
                {
                    case EnumDrawingType.LINE:
                        pGraphics.DrawLine(Pen, X, Y, X + Width, Y + Height);
                        break;
                    case EnumDrawingType.RECTANGLE:
                        pGraphics.DrawRectangle(Pen, X, Y, Width, Height);
                        break;
                    case EnumDrawingType.ELLIPSE:
                        pGraphics.DrawEllipse(Pen, X, Y, Width, Height);
                        break;
                }

            }
        }

        // --------- IDisposable stuff ---------
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EspackPrintingText() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
        // --------- until here ---------
    }

    // Image items class
    public class EspackPrintingImage : IEspackPrintingItem, IDisposable
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Graphics Graphics { get; set; }
        public bool EOL { get; set; }
        public bool PrintMe { get; set; }
        public bool Persistent { get; set; }
        public Image Image { get; set; }

        // Get the height for current text
        public float Height
        {
            get
            {
                return Image != null ? Image.Size.Height * 25.4F / Image.VerticalResolution : 0;
            }
        }

        // Get the width for current text
        public float Width
        {
            get
            {
                return Image != null ? Image.Size.Width * 25.4F / Image.HorizontalResolution : 0;
            }
        }

        public EspackPrintingImage(Image pImage,float pX=-1,float pY=-1,float pWidth=-1,float pHeight=-1, bool pEOL=false)
        {
            float percentWidth = 0;
            float percentHeight = 0;

            if (pWidth!=-1 || pHeight!=-1)
            {
                if (pWidth!=-1)
                    percentWidth = pWidth / pImage.Width;

                if (pHeight != -1)
                    percentHeight = pHeight / pImage.Height;

                percentWidth = (percentWidth != 0 ? percentWidth : percentHeight);
                percentHeight = (percentHeight != 0 ? percentHeight : percentWidth);

                int _newWidth = (int)(pImage.Size.Width * percentWidth);
                int _newHeight = (int)(pImage.Size.Height * percentHeight);

                Image = new Bitmap(_newWidth, _newHeight);

                using (Graphics graphicsHandle = Graphics.FromImage(Image))
                {
                    graphicsHandle.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    graphicsHandle.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    graphicsHandle.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    graphicsHandle.DrawImage(pImage, 0, 0, _newWidth, _newHeight);
                }
            }
            else
            { 
                Image = pImage;
            }
            
            X = pX;
            Y = pY;
            EOL = pEOL;
        }

        public void Draw(Graphics pGraphics)
        {
            if (pGraphics!=null)
                pGraphics.DrawImage(Image, X, Y);
        }

        // --------- IDisposable stuff ---------
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EspackPrintingText() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
        // --------- until here ---------
    }

    // Text items class
    public class EspackPrintingText : IEspackPrintingItem, IDisposable
    {
        public string Text { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public bool EOL { get; set; }       // End Of Line
        public Font Font { get; set; }
        public Brush Brush { get; set; }
        public Graphics Graphics { get; set; }
        public bool Persistent { get; set; }
        public bool Title { get; set; }
        public bool ForcedBold { get; set; }
        public bool ForcedUnderline { get; set; }
        public bool PrintMe { get; set; }

        // Get the height for current text
        public float Height
        {
            get
            {
                if (Graphics != null)
                    return Graphics.MeasureString(Text!=""?Text:"@", Font).Height;
                else return 0;
            }
        }

        // Get the width for current text
        public float Width
        {
            get
            {
                if (Graphics != null)
                {
                    return Graphics.MeasureString(Text != "" ? Text : "@", Font).Width - Graphics.MeasureString(" ", Font).Width;
                }
                else return 0;
            }
        }

        // Get the size (width,height)
        public PointF Size
        {
            get
            {
                return new PointF(Width, Height);
            }
        }

        // Constructor.
        public EspackPrintingText(string pText, EspackFont pFont=null, float pX=-1, float pY=-1, bool pEOL=false, bool pTitle=false)
        {
            Text = pText;
            Font = pFont != null ? pFont.Font : null;
            Brush = pFont != null ? pFont.Brush : null;
            X = pX;
            Y = pY;
            EOL = pEOL;
            Title = pTitle;
            Persistent = pTitle;
        }

        // Draw the text
        public void Draw(Graphics pGraphics)
        {
            if (Graphics != null)
                pGraphics.DrawString(Text, Font, Brush, X, Y);
        }

        // --------- IDisposable stuff ---------
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~EspackPrintingText() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
        // --------- until here ---------
    }

    // Class for grouping several EspackPringing objects
    public class EspackPrintingArea
    {
        public EnumDocumentZones Zone;
        public EnumZoneDocking Docking;

        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float MaxHeight { get; set; }
        public RectangleF RectangleF { get; set; }
        public int DataRows { get; set; } = 0;
        public int PermanentRows { get; set; } = 0;

        private EspackFont Font;
        private Pen Pen;

        //private Brush Brush;

        public List<object> Items { get; set; } = new List<object>();

        // Constructor
        public EspackPrintingArea(EnumDocumentZones pZone, RectangleF pArea, float pMaxHeight, EspackFont pFont = null, EnumZoneDocking pDocking = EnumZoneDocking.ALLOWED)
        {
            Zone = pZone;
            Docking = pDocking;

            // Set dimensions
            X = pArea.X;
            Y = pArea.Y;
            Width = pArea.Width;
            Height = pArea.Height;
            RectangleF = pArea;
            MaxHeight = pMaxHeight;

            // Set the font/brush.
            Font = pFont;

        }
        public EspackPrintingArea(EnumDocumentZones pZone, float pX, float pY, float pWidth, float pHeight, float pMaxHeight=-1, EspackFont pFont = null, EnumZoneDocking pDocking = EnumZoneDocking.ALLOWED)
            : this(pZone, new RectangleF(pX, pY, pWidth, pHeight), pMaxHeight, pFont, pDocking)
        {

        }
        public EspackPrintingArea(EnumDocumentZones pZone, EspackFont pFont = null, EnumZoneDocking pDocking = EnumZoneDocking.ALLOWED)
            : this(pZone, new RectangleF(-1, -1, -1, -1), -1, pFont, pDocking)
        {

        }

        // Add a text object to the list
        public void AddText(string pText, EspackFont pFont = null, float pX = -1, float pY = -1,bool pEOL=false,bool pTitle=false)
        {
            // Create and add the object to the list
            Items.Add(new EspackPrintingText(pText, pFont, pX, pY, pEOL, pTitle));
        }

        // Add an image to the list
        public void AddImage(Image pImage,float pX = -1, float pY = -1, float pWidth=-1,float pHeight=-1,bool pEOL = false)
        {
            // Create and add the object to the list
            Items.Add(new EspackPrintingImage(pImage,pX,pY,pWidth,pHeight,pEOL));
        }

        public void AddDrawing(EnumDrawingType pDrawType,float pX,float pY,float pWidth, float pHeight, Pen pPen=null)
        {
            // Create and add the object to the list
            Items.Add(new EspackPrintingDrawing(pDrawType, pX, pY, pWidth, pHeight, pPen));
        }
        // Move all X,Y units
        public void Move(float pX=0,float pY = 0)
        {
            Items.ForEach(_item =>
            {
                ((IEspackPrintingItem)_item).X += pX;
                ((IEspackPrintingItem)_item).Y += pY;
            });
        }

        // Convert all relative positions to absolute
        public void ArrangeItems(Graphics pGraphics, PointF HardMargins, EspackPrintingArea pPreviousArea)
        {

            if (pPreviousArea != null)
            {
                bool _setCoords = true;

                if (Docking != EnumZoneDocking.NONE)
                {
                    switch (pPreviousArea.Docking)
                    {
                        case EnumZoneDocking.RIGHTWARDS:
                            if (X == -1) X = pPreviousArea.X + pPreviousArea.Width + 2;
                            if (Y == -1) Y = pPreviousArea.Y;
                            _setCoords = false;
                            break;
                        case EnumZoneDocking.DOWNWARDS:
                            if (X == -1) X = pPreviousArea.X;
                            if (Y == -1) Y = pPreviousArea.Y + pPreviousArea.Height;
                            _setCoords = false;
                            break;
                    }
                }

                if (_setCoords)
                {
                    if (X == -1) X = HardMargins.X;
                    if (Y == -1) Y = pPreviousArea.Y + pPreviousArea.Height;
                }

                if (Font == null)
                    Font = pPreviousArea.Font;
            }
            else
            {
                // Set the min visible coordinates as default
                if (X == -1) X = HardMargins.X;
                if (Y == -1) Y = HardMargins.Y;
                Font = Font ?? new EspackFont();
            }

            // Calculate the X and Y for each item when they are not defined
            IEspackPrintingItem _previousItem = null;
            EspackPrintingText _previousText = null;
            Brush _previousBrush = null;
            Pen _previousPen = null;

            foreach (var _item in Items)
            {
                // Cast _item as IEspackPrintingItem
                var _currentItem = (IEspackPrintingItem)_item;
                _currentItem.Graphics = pGraphics;

                // If not ready to be printed, it needs to be arranged
                if (!_currentItem.PrintMe)
                {
                    if (_currentItem.GetType().Name != "EspackPrintingDrawing")
                    {
                        if (_previousItem != null)
                        {
                            // Previous item exists
                            if (_currentItem.X == -1 && _currentItem.Y == -1)
                            {
                                // X and Y not set. Set them depending of EOL value
                                if (!_previousItem.EOL)
                                {
                                    _currentItem.X = _previousItem.X + _previousItem.Width;
                                    _currentItem.Y = _previousItem.Y;
                                }
                                else
                                {
                                    if (Zone == EnumDocumentZones.BODY && _previousItem.Y + _previousItem.Height > MaxHeight)
                                    {
                                        break;
                                    }
                                    _currentItem.X = X; // LEFT MARGIN
                                    _currentItem.Y = _previousItem.Y + _previousItem.Height;
                                }
                            }
                        }
                        else
                        {
                            // First element: set defaults if not passed
                            _currentItem.X = _currentItem.X == -1 ? X : X + _currentItem.X; // LEFT MARGIN
                            _currentItem.Y = _currentItem.Y == -1 ? Y : Y + _currentItem.Y; // TOP MARGIN
                        }
                        // Only for text objects

                        if (_currentItem.GetType().Name == "EspackPrintingText")
                        {
                            // Cast it to EspackPrintingText
                            using (var _currentText = (EspackPrintingText)_currentItem)
                            {
                                if (_previousText != null)
                                {
                                    // Not the first text object
                                    if (_currentText.Font == null)
                                    {
                                        // Get the font from the previous object if set
                                        Font _f = _previousText.Font ?? (Font)Font.Font.Clone();

                                        // Disable the auto bold when the previous text was bold-forced and current is not a title
                                        if ((_previousText.ForcedBold || _previousText.ForcedUnderline) && !_currentText.Title)
                                            _f = new Font(_f.Name, _f.Size, _f.Style & (_previousText.ForcedBold?~FontStyle.Bold: _f.Style) & (_previousText.ForcedUnderline && Zone==EnumDocumentZones.BODY ? ~FontStyle.Underline : _f.Style));

                                        // Set current font
                                        _currentText.Font = _f;
                                    }

                                    // Set current brush
                                    if (_currentText.Brush == null)
                                        _currentText.Brush = _previousBrush ?? (Brush)Font.Brush.Clone();
                                }
                                else
                                {
                                    // First text object: set font / brush
                                    _currentText.Font = _currentText.Font ?? (Font)Font.Font.Clone();
                                    _currentText.Brush = _currentText.Brush ?? (Brush)Font.Brush.Clone();
                                }

                                // Force bold if current text is a title (and font was not bold)
                                if (_currentText.Title && !(_currentText.Font.Bold && _currentText.Font.Underline))
                                {
                                    _currentText.ForcedBold = !_currentText.Font.Bold;
                                    if (Zone==EnumDocumentZones.BODY)
                                        _currentText.ForcedUnderline = !_currentText.Font.Underline;
                                    _currentText.Font = new Font(_currentText.Font.Name, _currentText.Font.SizeInPoints, _currentText.Font.Style | FontStyle.Bold | (Zone == EnumDocumentZones.BODY?FontStyle.Underline:0));
                                }
                                _previousText = _currentText;
                                _previousBrush = _currentText.Brush;
                            }
                        }

                        // Calculate the Height / Width of current area
                        if (_currentItem.X - X + _currentItem.Width > Width)
                            Width = _currentItem.X - X + _currentItem.Width;
                        if (_currentItem.Y - Y + _currentItem.Height > Height)
                            Height = _currentItem.Y - Y + _currentItem.Height;
                    }
                    // Only for drawing objects (totally independent to the area)
                    else if (_currentItem.GetType().Name == "EspackPrintingDrawing")
                    {
                        if (((EspackPrintingDrawing)_currentItem).Pen==null)
                        {
                            ((EspackPrintingDrawing)_currentItem).Pen = _previousPen ?? (Pen)Pen.Clone();
                            ((EspackPrintingDrawing)_currentItem).Pen.Brush = _previousBrush ?? (Brush)Font.Brush.Clone();
                        }
                        _previousBrush = ((EspackPrintingDrawing)_currentItem).Pen.Brush;
                        _previousPen = ((EspackPrintingDrawing)_currentItem).Pen;
                    }

                    // Set current item as ready to be printed
                    _currentItem.PrintMe = true;
                }
                _previousItem = _currentItem;
            }
        }

        // Draw all the items in the area
        public void Draw(Graphics pGraphics)
        {
            // Draw those that have PrintMe==true 
            Items.Where(_item => (((IEspackPrintingItem)_item).PrintMe == true)).ToList().ForEach(_item =>
            {
                IEspackPrintingItem _printitem = ((IEspackPrintingItem)_item);
                _printitem.Draw(pGraphics);

                // For body zones, remove non persistent items after printing
                if (Zone==EnumDocumentZones.BODY && !_printitem.Persistent)
                    Items.Remove(_item);
            });
        }
    }

    // Class to manage the paging 
    public class EspackPageCounter
    {
        public bool Active { get; set; }
        public string Format { get; set; }
        public int Counter { get; set; }
        public int Total { get; set; }
        public int Rows { get; set; }
        public HorizontalAlignment Alignment { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public EspackFont Font { get; set; }
        public string Text
        {
            get
            {
                return string.Format(Format, Counter, Total);
            }
        }

        public EspackPageCounter(bool pActive = true, string pFormat = "Page {0} of {1}", HorizontalAlignment pAlignment = HorizontalAlignment.Right)
            : this(new EspackFont(pSize: 2), pActive, pFormat, pAlignment)
        {
            
        }
        public EspackPageCounter(EspackFont pFont, bool pActive = true, string pFormat = "Page {0} of {1}", HorizontalAlignment pAlignment = HorizontalAlignment.Right)
        {
            Font = pFont;
            Active = pActive;
            Format = pFormat;
            Alignment = pAlignment;
        }

        public PointF Size(Graphics pGraphics)
        {
            EspackPrintingText _textObj = new EspackPrintingText(string.Format(Format, Counter, Total), Font);
            _textObj.Graphics = pGraphics;
            return _textObj.Size;
        }
    }

    // Espack Print Document class
    public class EspackPrinting : PrintDocument
    {
        public EspackPrintingArea CurrentArea;                                                  // Current Area, in which all the actions will be done
        public List<EspackPrintingArea> Areas { get; set; } = new List<EspackPrintingArea>();   // List of areas in the document
        public EspackPageCounter Pager;
        public PointF HardMargins = new PointF(10F, 10F);
        public RectangleF VisibleArea;

        // Constructor
        public EspackPrinting()
        {
            Pager = new EspackPageCounter(true);
        }
        public EspackPrinting(EspackPageCounter pPager)
        {
            Pager = pPager;
        }

        // Add a new area and set it as current
        public void AddArea(EnumDocumentZones pZone, EspackFont pFont = null, EnumZoneDocking pDocking = EnumZoneDocking.NONE)
        {
            CurrentArea = new EspackPrintingArea(pZone, pFont, pDocking);
            Areas.Add(CurrentArea);
        }
        public void AddArea(EnumDocumentZones pZone, EnumZoneDocking pDocking)
        {
            AddArea(pZone, null, pDocking);
        }


        // Add a text item to the current area
        public void AddDrawing(float pX1, float pY1, float pX2, float pY2, EnumDrawingType pDrawType= EnumDrawingType.LINE, Pen pPen=null)
        {
            if (CurrentArea != null)
            {
                CurrentArea.AddDrawing(pDrawType, pX1, pY1, pX2-pX1,pY2-pY1, pPen);
            }
            else
            {
                MessageBox.Show("There is not current Area defined.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add a  item to the current area
        public void AddImage(Image pImage, float pX = -1, float pY = -1, float pWidth=-1,float pHeight=-1, bool pEOL = false)
        {
            if (CurrentArea != null)
            {
                CurrentArea.AddImage(pImage, pX, pY, pWidth,pHeight, pEOL);
            }
            else
            {
                MessageBox.Show("There is not current Area defined.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        // Add a text item to the current area
        public void AddText(string pText)
        {
            AddText(false,pText, null, -1, -1, false);
        }
        public void AddText(string pText, bool pEOL)
        {
            AddText(false,pText, null, -1, -1, pEOL);
        }
        public void AddText(bool pTitle,string pText)
        {
            AddText(pTitle, pText, null, -1, -1, false);
        }
        public void AddText(bool pTitle, string pText, bool pEOL)
        {
            AddText(pTitle, pText, null, -1, -1, pEOL);
        }
        public void AddText(string pText, EspackFont pFont = null, float pX = -1, float pY = -1, bool pEOL = false)
        {
            AddText(false, pText, pFont, pX, pY, pEOL);
        }
        public void AddText(bool pTitle,string pText, EspackFont pFont = null, float pX = -1, float pY = -1, bool pEOL= false)
        {
            if (CurrentArea!=null)
            {
                CurrentArea.AddText(pText, pFont, pX, pY, pEOL, pTitle);
            }
            else
            {
                MessageBox.Show("There is not current Area defined.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Change to the next line
        public void NewLine()
        {
            if (CurrentArea.Items.Count() != 0)
            {
                ((EspackPrintingText)CurrentArea.Items[CurrentArea.Items.Count() - 1]).EOL = true;
                //AddText("", null, -1, -1, true);
            }
        }

        // Add the results of a query to the current area
        public bool AddQuery(string pSQL, cAccesoDatosNet pConn, EspackFont pFont=null, bool pHideTitles=false)
        {

            using (var _rs = new DynamicRS(pSQL, pConn))
            {
                _rs.Open();
                if (_rs.RecordCount == 0)
                {
                    MessageBox.Show("The query returned no data.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {

                    Dictionary<string, List<string>> _matrix = new Dictionary<string, List<string>>();

                    foreach (var _item in _rs.Fields)
                    {
                        _matrix[_item.ToString()] = new List<string>();
                    }

                    int _col;

                    _rs.ToList().ForEach(_row =>
                    {
                        _col = 0;
                        _row.ItemArray.ToList().ForEach(_column =>
                        {
                            _matrix[_matrix.Keys.ToList()[_col]].Add(_column.ToString());
                            _col++;
                        });
                    });

                    foreach (var _key in _matrix.Keys)
                    {
                        Areas.Add(CurrentArea = new EspackPrintingArea(EnumDocumentZones.BODY, pFont, pDocking: EnumZoneDocking.RIGHTWARDS));

                        // Add current column title
                        if (!pHideTitles)
                        {
                            AddText(true, _key.ToString(), true);
                            CurrentArea.PermanentRows++;
                        }
                        // Add data for current column
                        foreach (var _item in _matrix[_key])
                        {
                            AddText(_item.ToString(), true);
                            CurrentArea.DataRows++;
                        }
                    }
                }
            }
            return true;
        }

        // OnPrintPage event, triggered on each new page
        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            EspackPrintingArea _previousArea = null;

            var _g = e.Graphics;
            _g.PageUnit = GraphicsUnit.Millimeter;
            

            if (Pager.Counter==0)
            {
                float _minBodyY = 0;
                float _maxBodyY = 0;

                //VisibleArea=new RectangleF(HardMargins.X,HardMargins.Y,_g.VisibleClipBounds.)
                VisibleArea = new RectangleF(_g.VisibleClipBounds.X, _g.VisibleClipBounds.Y, _g.VisibleClipBounds.Width, _g.VisibleClipBounds.Height);

                PointF _pagerSize;

                // Header areas
                Areas.Where(_item => (_item.Zone == EnumDocumentZones.HEADER)).ToList().ForEach(_item =>
                {
                    _item.ArrangeItems(_g, HardMargins, _previousArea);
                    _minBodyY = (_minBodyY < _item.Y + _item.Height) ? _item.Y + _item.Height : _minBodyY;
                    _previousArea = _item;
                });

                // Footer areas
                _previousArea = null;
                Areas.Where(_item => (_item.Zone == EnumDocumentZones.FOOTER)).ToList().ForEach(_item =>
                {
                    _item.ArrangeItems(_g, HardMargins, _previousArea);
                    _maxBodyY = (_maxBodyY < _item.Y + _item.Height) ? _item.Y + _item.Height : _maxBodyY;
                    _previousArea = _item;
                });

                _maxBodyY = _g.VisibleClipBounds.Bottom - HardMargins.Y - _maxBodyY;

                // If pager is active, we must take it into account
                if (Pager.Active)
                {
                    _pagerSize = Pager.Size(_g);
                    _maxBodyY -= _pagerSize.Y;
                    Pager.Y = _g.VisibleClipBounds.Bottom - HardMargins.Y - _pagerSize.Y;
                    Pager.X = _g.VisibleClipBounds.Right - HardMargins.X - _pagerSize.X; 
                }

                // Move the footer relative positions to its absolute place
                Areas.Where(_item => (_item.Zone == EnumDocumentZones.FOOTER)).ToList().ForEach(_item =>
                {
                    _item.Move(0, _maxBodyY);
                });

                // Set the Y limits for body areas
                Areas.Where(_item => (_item.Zone == EnumDocumentZones.BODY)).ToList().ForEach(_item =>
                {
                    _item.Y = _minBodyY;
                    _item.MaxHeight = _maxBodyY;
                    Pager.Rows = Pager.Rows < _item.Items.Count ? _item.Items.Count : Pager.Rows;
                });
                Pager.Counter = 1;
                Pager.Total = 1;
            }

            _previousArea = null;

            // body areas stuff
            Areas.Where(_item => (_item.Zone == EnumDocumentZones.BODY )).ToList().ForEach(_item =>
            {
                _item.ArrangeItems(_g,HardMargins,_previousArea);
                _previousArea = _item;
            });

            
            // printing            
            Areas.ForEach(_item =>
            {
                _item.Draw(_g);
                if (_item.Zone == EnumDocumentZones.BODY && Pager.Counter==1 && Pager.Total == 1 )
                    Pager.Total = (int)Math.Ceiling((_item.DataRows + 0.0) / (_item.DataRows - (_item.Items.Count - _item.PermanentRows)));
            });

            // paging
            if (Pager.Active)
            {
                _g.DrawString(Pager.Text, Pager.Font.Font, Pager.Font.Brush, Pager.X, Pager.Y);
            }
            e.HasMorePages = Pager.Counter < Pager.Total;
            Pager.Counter++;

            base.OnPrintPage(e);
        }

    }
}

