using Ingenico.Connect.Sdk;
using Ingenico.Connect.Sdk.Domain.Definitions;
using Ingenico.Connect.Sdk.Domain.Hostedcheckout;
using Ingenico.Connect.Sdk.Domain.Hostedcheckout.Definitions;
using Ingenico.Connect.Sdk.Domain.Payment.Definitions;
using Ingenico.Connect.Sdk.Merchant;
using Ingenico.Connect.Sdk.Merchant.Hostedcheckouts;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ingenico.API.Controllers
{
    [Route("[controller]")]
    public class CheckoutController : ApiController
    {
        private string MerchantId = "1069";
        private string API_Key_ID = "c9c815c2fd9b6c8b";
        private string Secret_API_Key = "wX+WEyDkG6Y+imNMv8/hsL+Sl0gGcruQwWZcde4bYqI=";

        public CheckoutController()
        {
        }

        [HttpPost]
        [Route("CreateHostedCheckout")]
        public async Task<CreateHostedCheckoutResponse> CreateHostedCheckout(CreateHostedCheckoutRequest createdHostedCheckout)
        {
            using (Client client = Factory.CreateClient(this.API_Key_ID, this.Secret_API_Key))
            {
                MerchantClient merchantClient = client.Merchant(this.MerchantId);
                HostedcheckoutsClient hostedCheckoutClient = merchantClient.Hostedcheckouts();
                var hostedCheckoutResponse = await hostedCheckoutClient.Create(createdHostedCheckout, null); 
                 /*{
                    //BankTransferPaymentMethodSpecificInput = new BankTransferPaymentMethodSpecificInputBase()
                    //{
                    //    AdditionalReference = "",
                    //    PaymentProductId = 1
                    //},
                    //CardPaymentMethodSpecificInput = new CardPaymentMethodSpecificInputBase() { 
                    //AuthorizationMode = "",
                    //CustomerReference = "",
                    //InitialSchemeTransactionId = "",
                    //PaymentProductId = "",
                    //Recurring = "",
                    //RecurringPaymentSequenceIndicator = "",
                    //RequiresApproval = "",
                    //SkipAuthentication = "",
                    //SkipFraudService = "",
                    //ThreeDSecure = "",
                    //Token = "e1831cec-bc9a-47d9-bf93-4bbcdaebe299",
                    //Tokenize = "",
                    //TransactionChannel ="",
                    //UnscheduledCardOnFileIndicator = "",
                    //UnscheduledCardOnFileRequestor = "",
                    //UnscheduledCardOnFileSequenceIndicator = ""
                    //},
                    //CashPaymentMethodSpecificInput = new CashPaymentMethodSpecificInputBase() { 
                    //PaymentProductId = "",
                    //},
                    //EInvoicePaymentMethodSpecificInput = null,
                    //FraudFields = null,
                    //Merchant = new Merchant() { 
                    //    ContactWebsiteUrl = "",
                    //    Seller = new Seller() { 
                    //        Address = new Address() { },
                    //        ChannelCode = "",
                    //        Description = "",
                    //        Geocode = "",
                    //        InvoiceNumber = "",
                    //        Mcc = "",
                    //        Name = "",
                    //        Type = ""
                    //    },
                    //    WebsiteUrl = ""
                    //},
                    //MobilePaymentMethodSpecificInput = null,
                    //RedirectPaymentMethodSpecificInput = null,
                    //SepaDirectDebitPaymentMethodSpecificInput = null,
                    Order = new Connect.Sdk.Domain.Payment.Definitions.Order()
                    {
                        //AdditionalInput = new AdditionalOrderInput() { 
                        //AirlineData = new AirlineData() { 
                        //AgentNumericCode = "",
                        //IssueDate = "",
                        //Code = "",
                        //FlightDate = "",
                        //FlightLegs = "",
                        //InvoiceNumber = "",
                        //IsETicket = "",
                        //IsRegisteredCustomer = "",
                        //IsRestrictedTicket = "",
                        //IsThirdParty ="",
                        //MerchantCustomerId = "1069",
                        //Name = "",
                        //PassengerName = "",
                        //Passengers = "",
                        //PlaceOfIssue ="",
                        //Pnr = "",
                        //PointOfSale ="",
                        //PosCityCode  = "",
                        //TicketDeliveryMethod = "",
                        //TicketNumber = "",
                        //TotalFare = "",
                        //TotalFee = "",
                        //TotalTaxes = "",
                        //TravelAgencyName = ""
                        //}
                        //},
                        //Items = null,
                        AmountOfMoney = new AmountOfMoney()
                        {
                            CurrencyCode = "EUR",
                            Amount = 1000
                        },
                        Customer = new Customer()
                        {
                            //    Account = new CustomerAccount() { 
                            //    Authentication = new CustomerAccountAuthentication() { },
                            //    ChangeDate = "",
                            //    ChangedDuringCheckout = false,
                            //    CreateDate = null,
                            //    HadSuspiciousActivity = false,
                            //    HasForgottenPassword = false,
                            //    HasPassword = false,
                            //    PasswordChangeDate = "",
                            //    PasswordChangedDuringCheckout = false,
                            //    PaymentAccountOnFile = new PaymentAccountOnFile() { 
                            //        CreateDate = "",
                            //        NumberOfCardOnFileCreationAttemptsLast24Hours = null
                            //    },
                            //    PaymentAccountOnFileType = "",
                            //    PaymentActivity = new CustomerPaymentActivity() { 
                            //        NumberOfPaymentAttemptsLast24Hours = null,
                            //        NumberOfPaymentAttemptsLastYear = null,
                            //        NumberOfPurchasesLast6Months = null
                            //    }
                            //},
                            //AccountType = "",
                            //CompanyInformation = new CompanyInformation() { 
                            //    Name = "",
                            //    VatNumber = ""
                            //},
                            //ContactDetails = new ContactDetails() { 
                            //    EmailAddress = "",
                            //    EmailMessageType="",
                            //    FaxNumber = "",
                            //    MobilePhoneNumber = "",
                            //    PhoneNumber = "",
                            //    WorkPhoneNumber = ""
                            //},
                            //Device = new CustomerDevice() { 
                            //    AcceptHeader="",
                            //    BrowserData = new BrowserData() { },
                            //    DefaultFormFill = "",
                            //    DeviceFingerprintTransactionId = "",
                            //    IpAddress = "",
                            //    Locale = "",
                            //    TimezoneOffsetUtcMinutes = "",
                            //    UserAgent = ""
                            //},
                            //FiscalNumber = "",
                            //IsPreviousCustomer = false,
                            //Locale = "en_GB",
                            //PersonalInformation = new PersonalInformation() { 
                            //DateOfBirth = "",
                            //Gender = ""
                            //,Name = ""
                            //},
                            //ShippingAddress = new AddressPersonal() { 
                            //     City = "",
                            //     AdditionalInfo = "",
                            //     CountryCode = "",
                            //     HouseNumber = "",
                            //     Name  = new PersonalName() { 
                            //     },
                            //     State = "",
                            //     StateCode = "",
                            //     Street = "",
                            //     Zip = ""
                            //},
                            //VatNumber = "",
                            BillingAddress = new Address()
                            {
                                CountryCode = "US"
                            },
                            MerchantCustomerId = "YOURCUSTOMERID"
                        }
                    }
                    ,
                    HostedCheckoutSpecificInput = new HostedCheckoutSpecificInput()
                    {
                        //    IsRecurring = null,
                        //    PaymentProductFilters = new PaymentProductFiltersHostedCheckout() { 
                        //        Exclude = new PaymentProductFilter() { 
                        //            Groups = null,
                        //            Products = null
                        //        },
                        //        RestrictTo = new PaymentProductFilter() { 
                        //            Groups = null,
                        //            Products = null
                        //        },
                        //        TokensOnly = null
                        //    },
                        //    ReturnCancelState = null,
                        //    ReturnUrl = null,
                        //      ShowResultPage = false,
                        //    Tokens = "",
                        //    ValidateShoppingCart = false,
                        Variant = "100",
                        Locale = "en_BE"
                    },
                    //EInvoicePaymentMethodSpecificInput = new EInvoicePaymentMethodSpecificInputBase() { 
                    //     PaymentProductId = 1,
                    //RequiresApproval = null
                    //},
                    //FraudFields = new FraudFields() { 
                    //AddressesAreIdentical = false,
                    //BlackListData = "",
                    //CardOwnerAddress = null,
                    //CustomerIpAddress = "",
                    //DefaultFormFill = "",
                    //DeviceFingerprintActivated = "",
                    //DeviceFingerprintTransactionId = "",
                    //GiftCardType = "",
                    //GiftMessage = "",
                    //HasForgottenPwd = "",
                    //HasPassword = "",
                    //IsPreviousCustomer = "",
                    //OrderTimezone = "",
                    //ShipComments = "",
                    //ShipmentTrackingNumber = "",
                    //ShippingDetails = "",
                    //UserData = "",
                    //Website = null
                    //},
                    //MobilePaymentMethodSpecificInput = new MobilePaymentMethodSpecificInputHostedCheckout() { 
                    //     PaymentProductId = null,
                    //     PaymentProduct320SpecificInput = new MobilePaymentProduct320SpecificInputHostedCheckout() { 
                    //          MerchantName = "Merchant 1069",
                    //          //MerchantOrigin = ""
                    //     }
                    //},
                    //RedirectPaymentMethodSpecificInput = new RedirectPaymentMethodSpecificInputBase() { 
                    //ExpirationPeriod = null,
                    //PaymentProduct840SpecificInput = new RedirectPaymentProduct840SpecificInputBase() { 
                    //    AddressSelectionAtPayPal = null,
                    //},
                    //RecurringPaymentSequenceIndicator = "",
                    //RequiresApproval = null,
                    //Token = "e1831cec-bc9a-47d9-bf93-4bbcdaebe299",
                    //Tokenize = true,
                    //    PaymentProductId = 1
                    //}
                    //,SepaDirectDebitPaymentMethodSpecificInput = new SepaDirectDebitPaymentMethodSpecificInputBase() { 
                    //PaymentProduct771SpecificInput = new SepaDirectDebitPaymentProduct771SpecificInputBase() { 
                    //        //ExistingUniqueMandateReference = "",
                    //        Mandate = new Connect.Sdk.Domain.Mandates.Definitions.CreateMandateBase() { 
                    //            //Alias = "",
                    //            Customer = new Connect.Sdk.Domain.Mandates.Definitions.MandateCustomer() { 
                    //                //BankAccountIban = "",
                    //                CompanyName = "DXC",
                    //                //MandateAddress = new Connect.Sdk.Domain.Mandates.Definitions.MandateAddress() { 
                    //                //    City = "",
                    //                //    CountryCode = "",
                    //                //    HouseNumber = "",
                    //                //    Street = "",
                    //                //    Zip = ""
                    //                //},
                    //                //Account = new CustomerAccount() { },
                    //                //AccountType = "",
                    //                //BillingAddress = new Address() { },
                    //                //CompanyInformation = new CompanyInformation() { },
                    //                //ContactDetails = new ContactDetails() { },
                    //                //Device = new CustomerDevice() { },
                    //                //FiscalNumber = "",
                    //                //IsPreviousCustomer = null,
                    //                //Locale = "",
                    //                //MerchantCustomerId = "",
                    //                //PersonalInformation = new PersonalInformation() { 
                    //                //    DateOfBirth = "",
                    //                //    Gender = "",
                    //                //    Name = new PersonalName() { 
                    //                //        FirstName = "",
                    //                //        Surname = "",
                    //                //        SurnamePrefix = "",
                    //                //        Title = ""
                    //                //    }
                    //                //},
                    //                //ShippingAddress = new AddressPersonal() { 
                    //                //    AdditionalInfo = "",
                    //                //    City = "",
                    //                //    CountryCode = "",
                    //                //    Name = "",
                    //                //    HouseNumber = "",
                    //                //    State = "",
                    //                //    StateCode = "",
                    //                //    Street = "",
                    //                //    Zip = ""
                    //                //},
                    //                //VatNumber = ""
                    //            },
                    //            //CustomerReference = "",
                    //            //Language = "",
                    //            //RecurrenceType = "",
                    //            //SignatureType = "",
                    //            //UniqueMandateReference = ""
                    //        }
                    //    }
                    //}
                }); ;*/

                hostedCheckoutResponse.PartialRedirectUrl = "https://payment." + hostedCheckoutResponse.PartialRedirectUrl;
                return hostedCheckoutResponse;
            }
        }

        [HttpGet]
        [Route("GetHostedCheckoutStatus")]
        public async Task<GetHostedCheckoutResponse> GetHostedCheckoutStatus()
        {
            using (Client client = Factory.CreateClient(this.API_Key_ID, this.Secret_API_Key))
            {
                MerchantClient merchantClient = client.Merchant(this.MerchantId);
                HostedcheckoutsClient hostedCheckoutClient = merchantClient.Hostedcheckouts();
                return await hostedCheckoutClient.Get("62bd42b8-7f79-4b79-b6f2-0e33bcadb0bc", null);
            }
        }
    }
}




/* ,BankTransferPaymentMethodSpecificInput = new Connect.Sdk.Domain.Payment.Definitions.BankTransferPaymentMethodSpecificInputBase() { },
CardPaymentMethodSpecificInput = new Connect.Sdk.Domain.Payment.Definitions.CardPaymentMethodSpecificInputBase() { },
CashPaymentMethodSpecificInput = new Connect.Sdk.Domain.Payment.Definitions.CashPaymentMethodSpecificInputBase() { },
EInvoicePaymentMethodSpecificInput = new Connect.Sdk.Domain.Payment.Definitions.EInvoicePaymentMethodSpecificInputBase() { },
FraudFields = new FraudFields() { },
Merchant = new Connect.Sdk.Domain.Payment.Definitions.Merchant() { },
MobilePaymentMethodSpecificInput = new MobilePaymentMethodSpecificInputHostedCheckout() { }
,RedirectPaymentMethodSpecificInput = new RedirectPaymentMethodSpecificInput() { },
SepaDirectDebitPaymentMethodSpecificInput = new SepaDirectDebitPaymentMethodSpecificInput() { }
}, null); */
