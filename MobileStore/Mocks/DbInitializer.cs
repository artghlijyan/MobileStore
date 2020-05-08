using MobileStore.DbRepo;
using MobileStore.Models;
using System.Linq;

namespace MobileStore.Mocks
{
    public static class DbInitializer
    {
        public static void Initialize(MobileContext mobilecontext)
        {
            if (!mobilecontext.Phones.Any())
            {
                mobilecontext.Phones.AddRange(
                    new Phone
                    {
                        Name = "iPhone XI",
                        Company = "Apple",
                        Price = 1100
                    },
                    new Phone
                    {
                        Name = "Samsung S20",
                        Company = "Samsung",
                        Price = 850
                    },
                    new Phone
                    {
                        Name = "Pixel 4",
                        Company = "Google",
                        Price = 950
                    }
                    );

                mobilecontext.SaveChanges();
            }
        }
    }
}
