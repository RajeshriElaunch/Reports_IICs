using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Framework
{
    public class EmailReportTable
    {
        string m_Titulo;
        public List<string> Items = new List<string>();

        public EmailReportTable(string Titulo)
        {
            m_Titulo = Titulo;
        }

        public string Render(bool important)
        {
            string color = "dce4ff";

            if (important)
                color = "d0dafd";

            string result = @"<table style=""width:95%; border: solid 1px #c1dad7"">

                    <thead style=""background-color: #" + color + ";\"><tr><td>" + m_Titulo + "</td></tr></thead>";

            result += @"<tbody style=""background-color: #eff2ff;font-size:11pt"">";

            foreach (string str in Items)

                result += "<tr><td>" + str + "</td></tr>";

            result += "<tr><td></td></tr></tbody></table>";

            return result;

        }



        public string Render()
        {

            return Render(false);

        }



    }
}
