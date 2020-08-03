using Ingenico.Connect.Sdk;
using Ingenico.Connect.Sdk.Domain.Definitions;
using Ingenico.Connect.Sdk.Domain.Hostedcheckout;
using Ingenico.Connect.Sdk.Domain.Hostedcheckout.Definitions;
using Ingenico.Connect.Sdk.Domain.Payment.Definitions;
using Ingenico.Connect.Sdk.Domain.Token;
using Ingenico.Connect.Sdk.Domain.Token.Definitions;
using Ingenico.Connect.Sdk.Merchant;
using Ingenico.Connect.Sdk.Merchant.Hostedcheckouts;
using Ingenico.Connect.Sdk.Merchant.Tokens;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;

namespace Ingenico.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : ApiController
    {
        private string MerchantId = "1069";
        private string API_Key_ID = "c9c815c2fd9b6c8b";
        private string Secret_API_Key = "wX+WEyDkG6Y+imNMv8/hsL+Sl0gGcruQwWZcde4bYqI=";
        private string Token_ID = "e1831cec-bc9a-47d9-bf93-4bbcdaebe299";

        // GET api/values
        [HttpGet]
        [Route("GetToken")]
        public async Task<TokenResponse> GetToken()
        {
            using (Client client = Factory.CreateClient(this.API_Key_ID, this.Secret_API_Key))
            {
                MerchantClient merchantClient = client.Merchant(this.MerchantId);
                TokensClient tokenClient = merchantClient.Tokens();
                var tokenResponse = await tokenClient.Get(this.Token_ID, null);

                return tokenResponse;
            }
        }

        [HttpGet]
        [Route("CreateToken")]
        public async Task<CreateTokenResponse> CreateToken()
        {
            using (Client client = Factory.CreateClient(this.API_Key_ID, this.Secret_API_Key))
            {
                MerchantClient merchantClient = client.Merchant(this.MerchantId);
                TokensClient tokenClient = merchantClient.Tokens();
                var tokenResponse = await tokenClient.Create(new CreateTokenRequest()
                {
                    PaymentProductId = 1,
                    Card = new Connect.Sdk.Domain.Token.Definitions.TokenCard()
                    {
                        Data = new Connect.Sdk.Domain.Token.Definitions.TokenCardData()
                        {
                            CardWithoutCvv = new CardWithoutCvv()
                            {
                                CardholderName = "Jayden White",
                                CardNumber = "4011109875491597",
                                ExpiryDate = "0425"
                            }
                        },
                        Customer = new Connect.Sdk.Domain.Token.Definitions.CustomerToken()
                        {
                            BillingAddress = new Address()
                            {
                                Street = "Desertroad",
                                HouseNumber = "13",
                                AdditionalInfo = "b",
                                Zip = "84536",
                                City = "Monument Valley",
                                State = "Utah",
                                CountryCode = "US"
                            },
                            CompanyInformation = new CompanyInformation()
                            {
                                Name = "Acme Labs"
                            },
                            PersonalInformation = new PersonalInformationToken()
                            {
                                Name = new PersonalNameToken()
                                {
                                    FirstName = "Wile",
                                    SurnamePrefix = "E.",
                                    Surname = "Coyote"
                                }
                            },
                            MerchantCustomerId = "1069",
                        },
                    }

                }, null);

                return tokenResponse;
            }
        }
        

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
