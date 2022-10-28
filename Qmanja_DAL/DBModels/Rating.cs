using System;
using System.Collections.Generic;

#nullable disable

namespace Qmanja_DAL.DBModels
{
    public partial class Rating
    {
        public Rating()
        {
            RatingCategories = new HashSet<RatingCategory>();
            RatingQuestions = new HashSet<RatingQuestion>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int SurveyId { get; set; }
        public int? BusinessDetailId { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual ICollection<RatingCategory> RatingCategories { get; set; }
        public virtual ICollection<RatingQuestion> RatingQuestions { get; set; }
    }
}
