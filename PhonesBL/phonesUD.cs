using PhonesDL;
using PhonesModel;

namespace PhonesBL
{
    public class phonesUD
    {
        phonesVS ValidationServices = new phonesVS();
        phonesData phoneData = new phonesData();

        public bool CreatePhone(Phones phones)
        {
            bool result = false;

            if (ValidationServices.CheckIfBrandExist(phones.Brand))
            {
                result = phoneData.AddPhones(phones) > 0;
            }

            return result;
        }

        public bool CreatePhone(string Brand, string Model, string Price)
        {
            Phones phones = new Phones { Brand = Brand, Model = Model, Price = Price };

            return CreatePhone(phones);
        }

        public bool UpdatePhone(Phones phones)
        {
            bool result = false;

            if (ValidationServices.CheckIfPhoneExist(phones.Brand, phones.Model, phones.Price))
            {
                result = phoneData.UpdatePhones(phones) > 0;
            }

            return result;
        }

        public bool UpdatePhone(string Brand, string Model, string Price)
        {
            Phones phones = new Phones { Brand = Brand, Model = Model, Price = Price };

            return UpdatePhone(phones);
        }

        public bool DeleteCar(Phones phones)
        {
            bool result = false;

            if (ValidationServices.CheckIfPhoneExist(phones.Brand, phones.Model, phones.Price))
            {
                result = phoneData.DeletePhones(phones) > 0;
            }

            return result;
        }
    }
}