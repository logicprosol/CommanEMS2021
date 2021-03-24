using System;
using System.IO;
using iTextSharp.text;

namespace CMS.Forms.Admin
{
    internal class HTMLWorker
    {
        private Document pdfDoc;

        public HTMLWorker(Document pdfDoc)
        {
            this.pdfDoc = pdfDoc;
        }

        internal void Parse(StringReader sr)
        {
            throw new NotImplementedException();
        }
        
    }
 }