using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public enum EnumDocumentParts { HEADER, BODY, FOOTER, NONE }

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
        public EnumDocumentParts CurrentPart { get; set; }
        public PrintableLine CurrentLine
        {
            get
            {
                switch (CurrentPart)
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
        public void NewLine(bool pBanding = false, EnumDocumentParts pPart=EnumDocumentParts.BODY)
        {
            var _line = new PrintableLine() { Banding = pBanding, LineNumber= BodyList.Lines.Count };
            _line.Add(new PrintableText(" ", CurrentFont));
            switch (pPart)
            {
                case EnumDocumentParts.HEADER:
                    HeaderList.Lines.Add(_line);
                    CurrentLineIndex = HeaderList.Lines.Count - 1;
                    CurrentPart = EnumDocumentParts.HEADER;
                    break;
                case EnumDocumentParts.BODY:
                    BodyList.Lines.Add(_line);
                    CurrentLineIndex = BodyList.Lines.Count - 1;
                    CurrentPart = EnumDocumentParts.BODY;
                    break;
                case EnumDocumentParts.FOOTER:
                    FooterList.Lines.Add(_line);
                    CurrentLineIndex = FooterList.Lines.Count - 1;
                    CurrentPart = EnumDocumentParts.FOOTER;
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




    /* ------------------------------------------------- */


    public interface IEspackPrintingItem
    {
        float X { get; set; }
        float Y { get; set; }
        Graphics Graphics { get; set; }
        float Height { get; }
        float Width { get; }
        void Draw(float x, float y);
        void Draw();
    }

    public class EspackPrintingText : IEspackPrintingItem
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Graphics Graphics { get; set; }
        public float Height
        {
            get
            {
                if (Graphics != null)
                    return Graphics.MeasureString(Text.Replace(' ', '@'), Font).Height;
                else return 0;
            }
        }
        public float Width
        {
            get
            {
                if (Graphics != null)
                    return Graphics.MeasureString(Text.Replace(' ', '@') + '@', Font).Width;
                else return 0;
            }
        }
        public string Text { get; set; }
        public Font Font { get; set; }
        public Brush Brush { get; set; }

        public EspackPrintingText(string ThisText, Font ThisFont, Brush ThisBrush, float ThisX, float ThisY)
        {
            Text = ThisText;
            Font = ThisFont;
            Brush = ThisBrush;
            X = ThisX;
            Y = ThisY;
        }

        public void Draw(float x, float y)
        {
            if (Graphics != null)
            {
                Graphics.DrawString(Text, Font, Brush, x, y);
            }
        }

        public void Draw()
        {
            if (Graphics != null)
            {
                Graphics.DrawString(Text, Font, Brush, X, Y);
            }
        }

    }


    public class EspackPrintingArea
    {
        private float _lastItemHeight;
        private float _lastItemWidth;

        public EnumDocumentParts DocumentArea;

        public float CurrentX { get; set; }
        public float CurrentY { get; set; }
        public float MinY { get; set; }
        public float MaxY { get; set; }
        public Font CurrentFont { get; set; }
        public Brush CurrentBrush { get; set; }

        public float LastItemHeight { get { return _lastItemHeight; } }
        public float LastItemWidth { get { return _lastItemWidth; } }

        public List<object> Items { get; set; } = new List<object>();

        public EspackPrintingArea(Font pFont = null,Brush pBrush=null)
        {
            // Set the default font/brush.
            CurrentFont = pFont == null ? new Font(FontFamily.GenericSansSerif, 10F, FontStyle.Regular) : pFont;
            CurrentBrush = pBrush == null ? new SolidBrush(Color.Black) : pBrush;

            // Set the last used item width/height (no items yet, so we set the value from a dummy object).
            EspackPrintingText _dummy = new EspackPrintingText("@", CurrentFont, CurrentBrush, 0, 0);
            _lastItemWidth = _dummy.Width;
            _lastItemHeight = _dummy.Height;
            _dummy = null;

            CurrentX = 0;
            CurrentY = 0;

            MinY = 0;
            MaxY = 39483948;
        }

        public void NewLine()
        {
            CurrentY = CurrentY + LastItemHeight;
        }

        public void AddText(string pText, Font pFont = null, Brush pBrush = null, float pX = -1, float pY = -1)
        {
            EspackPrintingText _textObj;
            bool _recalculateX = (pX == -1 && pY == -1);

            // When not passed, we use the current values.
            if (pFont == null)
                pFont = CurrentFont;
            if (pBrush == null)
                pBrush = CurrentBrush;
            if (pX == -1)
                pX = CurrentX;
            if (pY == -1)
                pY = CurrentX;

            // Create and add the object to the corresponding list.
            _textObj = new EspackPrintingText(pText, pFont, pBrush, pX, pY);
            Items.Add(_textObj);

            // Post operations
            if (_recalculateX)
                CurrentX = CurrentX + _lastItemWidth;
            _lastItemHeight = _textObj.Height;
            _lastItemWidth = _textObj.Width;
        }

    }

    public class EspackPrinting : PrintDocument
    {

        public EnumDocumentParts CurrentDocumentArea;
        
        public EspackPrintingArea HeaderArea { get; set; }
        public EspackPrintingArea BodyArea { get; set; }
        public EspackPrintingArea FooterArea { get; set; }

        public EspackPrinting()
        {
            HeaderArea = new EspackPrintingArea();
            BodyArea = new EspackPrintingArea();
            FooterArea = new EspackPrintingArea();
        }

        public void NewLine(EnumDocumentParts pDocumentArea=EnumDocumentParts.NONE)
        {
            // When not passed, we use the current values.
            if (pDocumentArea == EnumDocumentParts.NONE)
                pDocumentArea = CurrentDocumentArea;

            switch (pDocumentArea)
            {
                case EnumDocumentParts.HEADER:
                    HeaderArea.NewLine();
                    break;
                case EnumDocumentParts.BODY:
                    BodyArea.NewLine();
                    break;
                case EnumDocumentParts.FOOTER:
                    FooterArea.NewLine();
                    break;
            }
        }


        // Distinct versions of AddText.
        public void AddText(string pText)
        {
            AddText(pText, CurrentDocumentArea);
        }
        public void AddText(string pText, EnumDocumentParts pDocumentArea)
        {
            // When not passed, we use the current values.
            if (pDocumentArea == EnumDocumentParts.NONE)
                pDocumentArea = CurrentDocumentArea;

            AddText(pText, null, null, -1, -1, pDocumentArea);
        }

        public void AddText(string pText, Font pFont=null, Brush pBrush=null, float pX=-1, float pY=-1, EnumDocumentParts pDocumentArea = EnumDocumentParts.NONE)
        {
            // When not passed, we use the current values.
            if (pDocumentArea == EnumDocumentParts.NONE)
                pDocumentArea = CurrentDocumentArea;

            if (pDocumentArea == EnumDocumentParts.NONE)
                pDocumentArea = EnumDocumentParts.HEADER;

            CurrentDocumentArea = pDocumentArea;

            switch (pDocumentArea)
            {
                case EnumDocumentParts.HEADER:
                    HeaderArea.AddText(pText, pFont, pBrush, pX, pY);
                    break;
                case EnumDocumentParts.BODY:
                    BodyArea.AddText(pText, pFont, pBrush, pX, pY);
                    break;
                case EnumDocumentParts.FOOTER:
                    FooterArea.AddText(pText, pFont, pBrush, pX, pY);
                    break;
            }

        }

    }
}
