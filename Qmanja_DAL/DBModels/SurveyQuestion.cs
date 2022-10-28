using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class SurveyQuestion
    {
        public SurveyQuestion()
        {
            RatingQuestions = new HashSet<RatingQuestion>();
        }

        public int Id { get; set; }
        public string DisplayText { get; set; }
        public double MinimumRatingToShow { get; set; }
        public int SurveyId { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual ICollection<RatingQuestion> RatingQuestions { get; set; }
    }
}
