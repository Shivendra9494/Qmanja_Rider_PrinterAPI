using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class Survey
    {
        public Survey()
        {
            Ratings = new HashSet<Rating>();
            SurveyCategories = new HashSet<SurveyCategory>();
            SurveyQuestions = new HashSet<SurveyQuestion>();
        }

        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartFrom { get; set; }
        public DateTime EndOn { get; set; }
        public int BusinessDetailId { get; set; }
        public string DisplayOffer { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<SurveyCategory> SurveyCategories { get; set; }
        public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; }
    }
}
