using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class SurveyCategory
    {
        public SurveyCategory()
        {
            RatingCategories = new HashSet<RatingCategory>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int SurveyId { get; set; }
        public bool IsVisible { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual ICollection<RatingCategory> RatingCategories { get; set; }
    }
}
