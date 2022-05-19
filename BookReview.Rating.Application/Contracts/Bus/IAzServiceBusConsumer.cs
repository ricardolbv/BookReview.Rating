using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReview.Rating.Application.Contracts.Bus
{
    public interface IAzServiceBusConsumer
    {
        void Start();
        void Stop();
    }
}
