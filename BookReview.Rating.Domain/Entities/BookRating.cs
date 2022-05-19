using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Rating.Domain.Entities
{
    public class BookRating
    {
        int Id { get; set; }    
        int BookID { get; set; }    
        string Comment { get; set; }
        int Stars { get; set; }
        bool Recomendation { get; set; }   
    }
}
