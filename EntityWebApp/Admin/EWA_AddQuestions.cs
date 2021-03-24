using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityWebApp.Admin
{
    public class EWA_AddQuestions
    {
        public string Action { get; set; }

        public string Question { get; set; }

        public byte[] ImgQuestion { get; set; }

        public int IsImgQuestion { get; set; }

        public string Answer { get; set; }

        public string optA { get; set; }

        public string optB { get; set; }

        public string optC { get; set; }

        public string optD { get; set; }
        public int TestId { get; set; }

        public int OrgId { get; set; }
        public int Id { get; set; }

    }
}
