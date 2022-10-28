using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class RatingCategory
    {
        public int Id { get; set; }
        public int RatingStar { get; set; }
        public int SurveyCategoryId { get; set; }
        public int RatingId { get; set; }

        public virtual Rating Rating { get; set; }
        public virtual SurveyCategory SurveyCategory { get; set; }
    }
}
