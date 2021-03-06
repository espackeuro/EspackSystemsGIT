﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EspackClasses
{
    interface cEspackPreDefinedLabels
    {
        cLabel Label { get; set; }
        Dictionary<string, string> Parameters { get; set; }
        string ToString();

    }

    public class MicroCM : cEspackPreDefinedLabels
    {
        public cLabel Label { get; set; }
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
        public MicroCM(cLabel pLabel)
        {
            // Assignments
            Label = pLabel;
            //Parameters
            Parameters.Add("CM", "");
            Parameters.Add("RECEIVAL", "");
            Parameters.Add("RECEIVAL_DATE", "");
            Parameters.Add("PARTNUMBER", "");
            Parameters.Add("QTY", "");
            //label design
            var _middle = Label.width / 2F;
            var _left = 2F;
            var _right = Label.width - 4F;
            var _textsize = 7F;
            var _bcHeight = Label.height / 3F;
            var _pnYPos = 3 + _bcHeight + _textsize;
            var _bottomLineYPos = Label.height - 1F;
            Label.addLine(_middle, 3, 0, "C", "", "[BC][CM]", 0, _bcHeight - 1.5F, 1, false);
            Label.addLine(_middle, 6 + _bcHeight, 0, "C", "", "[CM]", _textsize * 2);
            Label.addLine(_middle, _pnYPos, 0, "C", "", "[PARTNUMBER]", _textsize);
            Label.addLine(_left, _bottomLineYPos, 0, "L", "", "REC#:[RECEIVAL]", _textsize);
            Label.addLine(_middle, _bottomLineYPos, 0, "C", "", "DATE:[RECEIVAL_DATE]", _textsize);
            Label.addLine(_right, _bottomLineYPos, 0, "R", "", "QTY:[QTY]  ", _textsize);
        }
        public override string ToString()
        {
            return Label.ToString(Parameters);
        }
    }
    public class SingleBarcode : cEspackPreDefinedLabels
    {
        public cLabel Label { get; set; }
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
        public SingleBarcode(cLabel pLabel)
        {
            // Assignments
            Label = pLabel;
            //Parameters
            Parameters.Add("VALUE", "");
            //label design
            var _middle = Convert.ToInt32(Label.width / 2F);
            var _right = Convert.ToInt32(Label.width) - 3;
            var _height = Convert.ToInt32(Label.height);
            Label.addLine(_middle, 3, 0, "C", "", "[BC][VALUE]", 0, _height / 2, 1, false);
            Label.addLine(_middle, _height / 2 + 8, 0, "C", "", "[VALUE]", 14);
        }
        public override string ToString()
        {
            return Label.ToString(Parameters);
        }
    }
    public class RackLabelWOL : cEspackPreDefinedLabels
    {
        public cLabel Label { get; set; }
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
        public RackLabelWOL(cLabel pLabel)
        {
            //Assignments
            Label = pLabel;
            //Parameters
            Parameters.Add("VALUE", "");
            Parameters.Add("HASHVAL", "");
            //Label Design
            var _middle = Convert.ToInt32(Label.width / 2f);
            var _right = Convert.ToInt32(Label.width) - 3;
            var _height = Convert.ToInt32(Label.height);
            Label.addLine(_middle, 13, 0, "C", "", "[VALUE]", 85, rotated: true);
            Label.addLine(_right, 75, 0, "I", "", "[BC][HASHVAL]", 0, _height / 4, 2, false, true);

        }
        public override string ToString()
        {
            return Label.ToString(Parameters);
        }
    }

    public class DealerPickPackHULabel : cEspackPreDefinedLabels
    {
        public cLabel Label { get; set; }
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
        public DealerPickPackHULabel(cLabel pLabel)
        {
            //Assignments
            Label = pLabel;
            //Parameters
            Parameters.Add("HU", "");
            Parameters.Add("ROUTE", "");
            Parameters.Add("DEALER", "");
            Parameters.Add("TYPE", "");
            Parameters.Add("DATE", "");
            //Label Design
            var _middle = Convert.ToInt32(Label.width / 2f);
            var _right = Convert.ToInt32(Label.width) - 3;
            var _height = Convert.ToInt32(Label.height);
            Label.addLine(2, 4, 0, "I", "", "Dealer Pick Pack", 8);
            Label.addLine(68, 4, 0, "D", "", "Espack - [DATE]",8);
            Label.addLine(_middle, 12, 0, "C", "", "[HU]", 22);
            Label.addLine(_middle, 14, 66, "C", "", "[BC][HU]", 0, 10, 2);//, 85,10);
            Label.addLine(_middle, 30, 0, "C", "", "[DEALER] / [ROUTE] / [TYPE]", 12);
            //Label.addLine(2, 30, 0, "I", "", "[DEALER]", 14);
            //Label.addLine(68, 30, 0, "D", "", "([ROUTE])", 14);
        }
        public override string ToString()
        {
            return Label.ToString(Parameters);
        }
    }
}
