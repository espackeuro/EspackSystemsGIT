﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiverseControls
{
    public interface PrintableThing
    {
        object Item { get; set; }
        Font Font { get; set; }
        Brush Brush { get; set; }
        Graphics Graphics { get; set; }
        float Height { get;  }
        float Width { get;  }
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
            if ( Graphics!= null)
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

    public class EspackPrintDocument:PrintDocument
    {
        public const float TOP_MARGIN = 15F;
        public const float BOTTOM_MARGIN = 15F;
        public const float LEFT_MARGIN = 15F;
        public const float RIGHT_MARGIN = 15F;
        public const float FOOTER_TOP = 20F;

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
        public void NewLine(bool pBanding = false, EnumDocumentParts pArea= EnumDocumentParts.BODY)
        {
            var _line = new PrintableLine() { Banding = pBanding, LineNumber= BodyList.Lines.Count };
            _line.Add(new PrintableText(" ", CurrentFont));
            switch (pArea)
            {
                case EnumDocumentParts.HEADER:
                    HeaderList.Lines.Add(_line);
                    CurrentLineIndex = HeaderList.Lines.Count - 1;
                    CurrentZone= EnumDocumentParts.HEADER;
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
            FooterList.Lines.RemoveAll(item=>true);
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
            if (BodyList.LastPrintedLine >1)
                PrintDocumentLine(BodyList.Lines[1], g, ref _y); // column titles in following new pages
            while (_y <= YMax && BodyList.LastPrintedLine < BodyList.Lines.Count )
            {
                PrintDocumentLine(BodyList.Lines[BodyList.LastPrintedLine], g, ref _y);
                BodyList.LastPrintedLine++;
            }

            // lets print the footer
            _y = YMax;
            FooterList.Lines.ForEach(l =>
            {
                PrintDocumentLine(l, g, ref _y);
            });

            // are going to be more pages?
            e.HasMorePages = (BodyList.LastPrintedLine < BodyList.Lines.Count);

            base.OnPrintPage(e);
        }
        private void PrintDocumentLine(PrintableLine Line, Graphics g, ref float _y)
        {
            //var l = BodyList.Lines[BodyList.LastPrintedLine];
            Line.Graphics = g;
            var _x = XMin;
            var __y = _y;
            if (Line.Banding && (Line.LineNumber % 2 == 0))
                g.FillRectangle(new SolidBrush(Color.GhostWhite), XMin, _y, Line.Width, Line.Height);
            Line.Things.ForEach(t =>
            {
                t.Draw(_x, __y);
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

    // Interface
    public interface IEspackPrintingItem
    {
        float X { get; set; }
        float Y { get; set; }
        Graphics Graphics { get; set; }
        float Height { get; }
        float Width { get; }
        void Draw();
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
            catch(Exception)
            {
                pFamily=new FontFamily("Tahoma");
            }
            Font = new Font(pFamily, pSize, pStyle, GraphicsUnit.Millimeter);
            Brush = pBrush ?? new SolidBrush(Color.Black);
        }
    }

    // Text items class
    public class EspackPrintingText : IEspackPrintingItem,IDisposable
    {
        public string Text { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public bool EOL { get; set; }       // End Of Line
        public Font Font { get; set; }
        public Brush Brush { get; set; }

        public Graphics Graphics { get; set; }

        // Get the height for current text
        public float Height
        {
            get
            {
                if (Graphics != null)
                    return Graphics.MeasureString(Text, Font).Height;
                else return 0;
            }
        }
        
        // Get the width for current text
        public float Width
        {
            get
            {
                if (Graphics != null)
                    return Graphics.MeasureString(Text, Font).Width;
                else return 0;
            }
        }

        // Constructor.
        public EspackPrintingText(string pText, EspackFont pFont, float pX, float pY, bool pEOL)
        {
            Text = pText;
            Font = pFont != null ? pFont.Font : null;
            Brush = pFont != null ? pFont.Brush : null;
            X = pX;
            Y = pY;
            EOL = pEOL;
        }

        // Draw the text
        public void Draw()
        {
            if (Graphics!=null)
                Graphics.DrawString(Text, Font, Brush, X, Y);
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
        public RectangleF RectangleF { get; set; }

        private EspackFont Font;
        //private Brush Brush;

        public List<object> Items { get; set; } = new List<object>();

        // Constructor
        public EspackPrintingArea(EnumDocumentZones pZone, RectangleF pArea, EspackFont pFont = null, EnumZoneDocking pDocking = EnumZoneDocking.ALLOWED)
        {
            Zone = pZone;
            Docking = pDocking;

            // Set dimensions
            X = pArea.X;
            Y = pArea.Y;
            Width = pArea.Width;
            Height = pArea.Height;
            RectangleF = pArea;

            // Set the font/brush.
            Font = pFont;

        }
        public EspackPrintingArea(EnumDocumentZones pZone, float pX, float pY, float pWidth, float pHeight, EspackFont pFont = null, EnumZoneDocking pDocking = EnumZoneDocking.ALLOWED)
            : this(pZone, new RectangleF(pX, pY, pWidth, pHeight), pFont, pDocking)
        {

        }
        public EspackPrintingArea(EnumDocumentZones pZone, EspackFont pFont = null, EnumZoneDocking pDocking = EnumZoneDocking.ALLOWED)
            : this(pZone, new RectangleF(-1, -1, -1, -1), pFont, pDocking)
        {

        }

        // Add a text object to the list
        public void AddText(string pText, EspackFont pFont = null, float pX = -1, float pY = -1,bool pEOL=false)
        {
            // Create and add the object to the list
            Items.Add(new EspackPrintingText(pText, pFont, pX, pY, pEOL));
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
        public void ArrangeItems(Graphics pGraphics,PointF HardMargins, EspackPrintingArea pPreviousArea)
        {
    
            EspackPrintingText _previousText = null;

            if (pPreviousArea != null)
            {
                switch (Docking)
                {
                    case EnumZoneDocking.RIGHTWARDS:
                        if (X == -1) X = pPreviousArea.X + pPreviousArea.Width;
                        if (Y == -1) Y = pPreviousArea.Y;
                        break;
                    case EnumZoneDocking.DOWNWARDS:
                        if (X == -1) X = pPreviousArea.X;
                        if (Y == -1) Y = pPreviousArea.Y + pPreviousArea.Height;
                        break;
                    default:
                        if (X == -1) X = HardMargins.X;
                        if (Y == -1) Y = pPreviousArea.Y + pPreviousArea.Height;
                        break;
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
            Items.ForEach(x =>
            {
                // Text items
                if (x.GetType().Name == "EspackPrintingText")
                {
                    ((IEspackPrintingItem)x).Graphics = pGraphics;

                    using (var _currentItem = ((EspackPrintingText)x))
                    {
                        if (_previousText != null)
                        {
                            // Previous item exists
                            if (_currentItem.X == -1 && _currentItem.Y == -1)
                            {
                                // X and Y not set. Set them depending of EOL value
                                if (!_previousText.EOL)
                                {
                                    _currentItem.X = _previousText.X + _previousText.Width;
                                    _currentItem.Y = _previousText.Y;
                                }
                                else
                                {
                                    _currentItem.X = X; // LEFT MARGIN
                                    _currentItem.Y = _previousText.Y + _previousText.Height;
                                }
                            }
                            if (_currentItem.Font == null)
                                _currentItem.Font = _previousText.Font??Font.Font;
                            if (_currentItem.Brush == null)
                                _currentItem.Brush = _previousText.Brush??Font.Brush;
                            

                        }
                        else
                        {
                            // First element: set defaults if not passed
                            _currentItem.X = _currentItem.X == -1 ? X : X + _currentItem.X; // LEFT MARGIN
                            _currentItem.Y = _currentItem.Y == -1 ? Y : Y + _currentItem.Y; // TOP MARGIN
                            _currentItem.Font = _currentItem.Font ?? Font.Font;
                            _currentItem.Brush = _currentItem.Brush ?? Font.Brush;
                        }
                        if (_currentItem.X + _currentItem.Width > Width)
                            Width = _currentItem.X + _currentItem.Width;
                        if (_currentItem.Y + _currentItem.Height> Height)
                            Height = _currentItem.Y + _currentItem.Height;

                        _previousText = _currentItem;
                    }
                    
                }
                
            });
        }

        // Draw all the items in the area
        public void Draw()
        {
            // Draw them
            Items.ForEach(_item =>
            {
                ((IEspackPrintingItem)_item).Draw();
            });
        }
    }

    // Espack Print Document class
        public class EspackPrinting : PrintDocument
    {

        public EspackPrintingArea CurrentArea;                                                  // Current Area, in which all the actions will be done
        public List<EspackPrintingArea> Areas { get; set; } = new List<EspackPrintingArea>();   // List of areas in the document
        private bool FirstPage = true;                                                          // Control the first iteration of OnPrintPage event
        //private int PageCounter=1;
        //private int TotalPages;
        public struct PageCounter
        {
            public bool Active;
            public string Format;
            public int Counter;
            public int Total;
        }
        public PageCounter Pager=new PageCounter();

        // Constructor
        public EspackPrinting()
        {
            Pager.Active = true;
            Pager.Format = "Page {0} of {1}";
            Pager.Counter = 0;
            Pager.Total = 0;
        }
        public EspackPrinting(PageCounter pPager)
        {
            Pager = pPager;
        }

        // Add a new area and set it as current
        public void AddArea(EnumDocumentZones pZone,EspackFont pFont=null, EnumZoneDocking pDocking=EnumZoneDocking.NONE)
        {
            CurrentArea = new EspackPrintingArea(pZone, pFont, pDocking);
            Areas.Add(CurrentArea);
        }

        // Add a text item to the current area
        public void AddText(string pText)
        {
            AddText(pText, null, -1, -1, false);
        }
        public void AddText(string pText, bool pEOL)
        {
            AddText(pText, null, -1, -1, pEOL);
        }
        public void AddText(string pText, EspackFont pFont = null, float pX = -1, float pY = -1, bool pEOL= false)
        {
            if (CurrentArea!=null)
            {
                CurrentArea.AddText(pText, pFont, pX, pY, pEOL);
            }
            else
            {
                MessageBox.Show("There is not current Area defined.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /*
        private void potas(PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Millimeter;

            Image img = new Bitmap(@"c:\Sunset.jpg");
            Graphics gg = Graphics.FromImage(img);


            RectangleF marginBounds = e.MarginBounds;
            if (!PrintController.IsPreview)
                marginBounds.Offset(-e.PageSettings.HardMarginX,
                                -e.PageSettings.HardMarginY);

            float x = marginBounds.X / 100f +
                            (marginBounds.Width / 100f -
                                (float)img.Width / gg.DpiX) / 2f;
            float y = marginBounds.Y / 100f +
                            (marginBounds.Height / 100f -
                                (float)img.Height / gg.DpiY) / 2f;



            g.DrawImage(img, x, y);

            //Don't call g.Dispose(). Operating System will do this job.
            gg.Dispose();//You should call it to release graphics object immediately.
        }
        */

        // OnPrintPage event, triggered on each new page
        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            EspackPrintingArea _previousArea = null;

            var _g = e.Graphics;
            _g.PageUnit = GraphicsUnit.Millimeter;
            //_g.VisibleClipBounds

            //potas(e);
           

            if (FirstPage)
            {
                float _minBodyY = 0;
                float _maxBodyY = 0;

                PointF _hardMargins = new PointF(10F, 10F);

                // Header areas
                Areas.Where(_item => (_item.Zone == EnumDocumentZones.HEADER)).ToList().ForEach(_item =>
                {
                    _item.ArrangeItems(_g, _hardMargins, _previousArea);
                    _minBodyY = (_minBodyY < _item.Y + _item.Height) ? _item.Y + _item.Height : _minBodyY;
                    _previousArea = _item;
                });

                // Footer areas
                _previousArea = null;
                Areas.Where(_item => (_item.Zone == EnumDocumentZones.FOOTER)).ToList().ForEach(_item =>
                {
                    _item.ArrangeItems(_g, _hardMargins, _previousArea);
                    _maxBodyY = (_maxBodyY < _item.Y + _item.Height) ? _item.Y + _item.Height : _maxBodyY;
                    _previousArea = _item;
                });
                _maxBodyY = _g.VisibleClipBounds.Bottom - _hardMargins.Y - _maxBodyY;

                // Move the footer relative positions to its absolute place
                Areas.Where(_item => (_item.Zone == EnumDocumentZones.FOOTER)).ToList().ForEach(_item =>
                {
                    _item.Move(0, _maxBodyY);
                });

                // Set the Y limits for body areas
                Areas.Where(_item => (_item.Zone == EnumDocumentZones.BODY)).ToList().ForEach(_item =>
                {
                    _item.Y = _minBodyY;
                    _item.Height = _maxBodyY;
                });
                FirstPage = false;
            }

            _previousArea = null;

            // body areas stuff
            /*
            Areas.Where(x => (x.Zone == EnumDocumentZones.BODY )).ToList().ForEach(x =>
            {
                x.ArrangeItems(_g,_previousArea);
            });
            */
            

            // printing            
            Areas.ForEach(_item =>
            {
                _item.Draw();
            });

            // paging
            //e.HasMorePages = (BodyList.LastPrintedLine < BodyList.Lines.Count);

            if (Pager.Active)
            {
                Pager.Counter++;
                Pager.Total = 1;
                _g.DrawString(String.Format(Pager.Format, Pager.Counter, Pager.Total), new Font(FontFamily.GenericSansSerif, 10F, FontStyle.Regular, GraphicsUnit.Millimeter), new SolidBrush(Color.Black), _g.VisibleClipBounds.Right - 100F, _g.VisibleClipBounds.Bottom - 50F);
            }


            base.OnPrintPage(e);
        }

    }
}
