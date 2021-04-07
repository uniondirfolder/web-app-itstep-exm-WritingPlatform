using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingPlatformCore.ValueObjects
{
    public class RecommendGiveAdvice
    {
        public string Address { get; private set; }
        private RecommendGiveAdvice() { }
        public RecommendGiveAdvice(string address = null)
        {
            Address = address;
        }
    }
}
