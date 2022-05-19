using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Rating.Infraestructure
{
    public static class EnvVariables
    {
        public static string TOPIC_BUS => "bookclassificationmessage";
        public static string SERVICE_BUS_STRING => "Endpoint=sb://book-review.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Rq591Auu4s/G1d1Pj9Fxl8mTWVZBDD2BVFRMhUCpR2I=";
        public static string SUBSCRIPTION_NAME => "book-rating";
    }
}
