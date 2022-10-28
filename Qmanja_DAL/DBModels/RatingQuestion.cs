using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class RatingQuestion
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public int RatingId { get; set; }
        public int SurveyQuestionId { get; set; }

        public virtual Rating Rating { get; set; }
        public virtual SurveyQuestion SurveyQuestion { get; set; }
    }
}
