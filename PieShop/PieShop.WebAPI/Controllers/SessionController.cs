using Ingenico.Connect.Sdk;
using Ingenico.Connect.Sdk.Domain.Definitions;
using Ingenico.Connect.Sdk.Domain.Sessions;
using Ingenico.Connect.Sdk.Domain.Sessions.Definitions;
using Ingenico.Connect.Sdk.Merchant;
using Ingenico.Connect.Sdk.Merchant.Sessions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;

namespace Ingenico.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SessionController : ApiController
    {
        private string MerchantId = "1069";
        private string API_Key_ID = "c9c815c2fd9b6c8b";
        private string Secret_API_Key = "wX+WEyDkG6Y+imNMv8/hsL+Sl0gGcruQwWZcde4bYqI=";
        private string Token_ID = "e1831cec-bc9a-47d9-bf93-4bbcdaebe299";

        [HttpGet]
        [Route("CreateSession")]
        public async Task<SessionResponse> CreateSession()
        {
            using (Client client = Factory.CreateClient(this.API_Key_ID, this.Secret_API_Key))
            {
                try
                {
                    MerchantClient merchantClient = client.Merchant(this.MerchantId);
                    SessionsClient sessionClient = merchantClient.Sessions();

                    var sessionResponse = await sessionClient.Create(new SessionRequest()
                    {
                        //PaymentProductFilters = new PaymentProductFiltersClientSession() { 
                        //    Exclude = new PaymentProductFilter() { 
                        //        Groups = { "", "", ""},
                        //        Products = { null, null, null }
                        //    },
                        //    RestrictTo = new PaymentProductFilter() { 
                        //        Groups = { "", "", ""},
                        //        Products = { null, null, null}
                        //    }
                        //},
                        Tokens = new List<string>(){
                            "e1831cec-bc9a-47d9-bf93-4bbcdaebe299"
                        }

                    }, null);

                    return sessionResponse;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        // GET api/values
        //[HttpGet]
        //[Route("GetToken")]
        //public async Task<TokenResponse> GetToken()
        //{
        //    using (Client client = Factory.CreateClient(this.API_Key_ID, this.Secret_API_Key))
        //    {
        //        MerchantClient merchantClient = client.Merchant(this.MerchantId);
        //        TokensClient tokenClient = merchantClient.Tokens();
        //        var tokenResponse = await tokenClient.Get(this.Token_ID, null);

        //        return tokenResponse;
        //    }
        //}

        //[HttpGet]
        //[Route("CreateToken")]
        //public async Task<CreateTokenResponse> CreateToken()
        //{
        //    using (Client client = Factory.CreateClient(this.API_Key_ID, this.Secret_API_Key))
        //    {
        //        MerchantClient merchantClient = client.Merchant(this.MerchantId);
        //        TokensClient tokenClient = merchantClient.Tokens();
        //        var tokenResponse = await tokenClient.Create(new CreateTokenRequest()
        //        {
        //            PaymentProductId = 1,
        //            Card = new Connect.Sdk.Domain.Token.Definitions.TokenCard()
        //            {
        //                Data = new Connect.Sdk.Domain.Token.Definitions.TokenCardData()
        //                {
        //                    CardWithoutCvv = new CardWithoutCvv()
        //                    {
        //                        CardholderName = "Jayden White",
        //                        CardNumber = "4011109875491597",
        //                        ExpiryDate = "0425"
        //                    }
        //                },
        //                Customer = new Connect.Sdk.Domain.Token.Definitions.CustomerToken()
        //                {
        //                    BillingAddress = new Address()
        //                    {
        //                        Street = "Desertroad",
        //                        HouseNumber = "13",
        //                        AdditionalInfo = "b",
        //                        Zip = "84536",
        //                        City = "Monument Valley",
        //                        State = "Utah",
        //                        CountryCode = "US"
        //                    },
        //                    CompanyInformation = new CompanyInformation()
        //                    {
        //                        Name = "Acme Labs"
        //                    },
        //                    PersonalInformation = new PersonalInformationToken()
        //                    {
        //                        Name = new PersonalNameToken()
        //                        {
        //                            FirstName = "Wile",
        //                            SurnamePrefix = "E.",
        //                            Surname = "Coyote"
        //                        }
        //                    },
        //                    MerchantCustomerId = "1069",
        //                },
        //            }

        //        }, null);

        //        return tokenResponse;
        //    }
        //}

        //[HttpGet]
        //[Route("GetHostedCheckoutStatus")]
        //public async Task<GetHostedCheckoutResponse> GetHostedCheckoutStatus()
        //{
        //    using (Client client = Factory.CreateClient(this.API_Key_ID, this.Secret_API_Key))
        //    {
        //        MerchantClient merchantClient = client.Merchant(this.MerchantId);
        //        HostedcheckoutsClient hostedCheckoutClient = merchantClient.Hostedcheckouts();
        //        return await hostedCheckoutClient.Get("62bd42b8-7f79-4b79-b6f2-0e33bcadb0bc", null);
        //    }
        //}

        //[HttpGet]
        //[Route("CreateHostedCheckout")]
        //public async Task<CreateHostedCheckoutResponse> CreateHostedCheckout()
        //{
        //    using (Client client = Factory.CreateClient(this.API_Key_ID, this.Secret_API_Key))
        //    {
        //        MerchantClient merchantClient = client.Merchant(this.MerchantId);
        //        HostedcheckoutsClient hostedCheckoutClient = merchantClient.Hostedcheckouts();
        //        var hostedCheckoutResponse = await hostedCheckoutClient.Create(new CreateHostedCheckoutRequest()
        //        {
        //            //BankTransferPaymentMethodSpecificInput = new BankTransferPaymentMethodSpecificInputBase()
        //            //{
        //            //    AdditionalReference = "",
        //            //    PaymentProductId = 1
        //            //},
        //            //CardPaymentMethodSpecificInput = new CardPaymentMethodSpecificInputBase() { 
        //            //AuthorizationMode = "",
        //            //CustomerReference = "",
        //            //InitialSchemeTransactionId = "",
        //            //PaymentProductId = "",
        //            //Recurring = "",
        //            //RecurringPaymentSequenceIndicator = "",
        //            //RequiresApproval = "",
        //            //SkipAuthentication = "",
        //            //SkipFraudService = "",
        //            //ThreeDSecure = "",
        //            //Token = "e1831cec-bc9a-47d9-bf93-4bbcdaebe299",
        //            //Tokenize = "",
        //            //TransactionChannel ="",
        //            //UnscheduledCardOnFileIndicator = "",
        //            //UnscheduledCardOnFileRequestor = "",
        //            //UnscheduledCardOnFileSequenceIndicator = ""
        //            //},
        //            //CashPaymentMethodSpecificInput = new CashPaymentMethodSpecificInputBase() { 
        //            //PaymentProductId = "",
        //            //},
        //            //EInvoicePaymentMethodSpecificInput = null,
        //            //FraudFields = null,
        //            //Merchant = new Merchant() { 
        //            //    ContactWebsiteUrl = "",
        //            //    Seller = new Seller() { 
        //            //        Address = new Address() { },
        //            //        ChannelCode = "",
        //            //        Description = "",
        //            //        Geocode = "",
        //            //        InvoiceNumber = "",
        //            //        Mcc = "",
        //            //        Name = "",
        //            //        Type = ""
        //            //    },
        //            //    WebsiteUrl = ""
        //            //},
        //            //MobilePaymentMethodSpecificInput = null,
        //            //RedirectPaymentMethodSpecificInput = null,
        //            //SepaDirectDebitPaymentMethodSpecificInput = null,
        //            Order = new Connect.Sdk.Domain.Payment.Definitions.Order()
        //            {
        //                //AdditionalInput = new AdditionalOrderInput() { 
        //                //AirlineData = new AirlineData() { 
        //                //AgentNumericCode = "",
        //                //IssueDate = "",
        //                //Code = "",
        //                //FlightDate = "",
        //                //FlightLegs = "",
        //                //InvoiceNumber = "",
        //                //IsETicket = "",
        //                //IsRegisteredCustomer = "",
        //                //IsRestrictedTicket = "",
        //                //IsThirdParty ="",
        //                //MerchantCustomerId = "1069",
        //                //Name = "",
        //                //PassengerName = "",
        //                //Passengers = "",
        //                //PlaceOfIssue ="",
        //                //Pnr = "",
        //                //PointOfSale ="",
        //                //PosCityCode  = "",
        //                //TicketDeliveryMethod = "",
        //                //TicketNumber = "",
        //                //TotalFare = "",
        //                //TotalFee = "",
        //                //TotalTaxes = "",
        //                //TravelAgencyName = ""
        //                //}
        //                //},
        //                //Items = null,
        //                AmountOfMoney = new AmountOfMoney()
        //                {
        //                    CurrencyCode = "EUR",
        //                    Amount = 1000
        //                },
        //                Customer = new Customer()
        //                {
        //                    //    Account = new CustomerAccount() { 
        //                    //    Authentication = new CustomerAccountAuthentication() { },
        //                    //    ChangeDate = "",
        //                    //    ChangedDuringCheckout = false,
        //                    //    CreateDate = null,
        //                    //    HadSuspiciousActivity = false,
        //                    //    HasForgottenPassword = false,
        //                    //    HasPassword = false,
        //                    //    PasswordChangeDate = "",
        //                    //    PasswordChangedDuringCheckout = false,
        //                    //    PaymentAccountOnFile = new PaymentAccountOnFile() { 
        //                    //        CreateDate = "",
        //                    //        NumberOfCardOnFileCreationAttemptsLast24Hours = null
        //                    //    },
        //                    //    PaymentAccountOnFileType = "",
        //                    //    PaymentActivity = new CustomerPaymentActivity() { 
        //                    //        NumberOfPaymentAttemptsLast24Hours = null,
        //                    //        NumberOfPaymentAttemptsLastYear = null,
        //                    //        NumberOfPurchasesLast6Months = null
        //                    //    }
        //                    //},
        //                    //AccountType = "",
        //                    //CompanyInformation = new CompanyInformation() { 
        //                    //    Name = "",
        //                    //    VatNumber = ""
        //                    //},
        //                    //ContactDetails = new ContactDetails() { 
        //                    //    EmailAddress = "",
        //                    //    EmailMessageType="",
        //                    //    FaxNumber = "",
        //                    //    MobilePhoneNumber = "",
        //                    //    PhoneNumber = "",
        //                    //    WorkPhoneNumber = ""
        //                    //},
        //                    //Device = new CustomerDevice() { 
        //                    //    AcceptHeader="",
        //                    //    BrowserData = new BrowserData() { },
        //                    //    DefaultFormFill = "",
        //                    //    DeviceFingerprintTransactionId = "",
        //                    //    IpAddress = "",
        //                    //    Locale = "",
        //                    //    TimezoneOffsetUtcMinutes = "",
        //                    //    UserAgent = ""
        //                    //},
        //                    //FiscalNumber = "",
        //                    //IsPreviousCustomer = false,
        //                    //Locale = "en_GB",
        //                    //PersonalInformation = new PersonalInformation() { 
        //                    //DateOfBirth = "",
        //                    //Gender = ""
        //                    //,Name = ""
        //                    //},
        //                    //ShippingAddress = new AddressPersonal() { 
        //                    //     City = "",
        //                    //     AdditionalInfo = "",
        //                    //     CountryCode = "",
        //                    //     HouseNumber = "",
        //                    //     Name  = new PersonalName() { 
        //                    //     },
        //                    //     State = "",
        //                    //     StateCode = "",
        //                    //     Street = "",
        //                    //     Zip = ""
        //                    //},
        //                    //VatNumber = "",
        //                    BillingAddress = new Address()
        //                    {
        //                        CountryCode = "US"
        //                    },
        //                    MerchantCustomerId = "YOURCUSTOMERID"
        //                }
        //            }
        //            ,
        //            HostedCheckoutSpecificInput = new HostedCheckoutSpecificInput()
        //            {
        //                //    IsRecurring = null,
        //                //    PaymentProductFilters = new PaymentProductFiltersHostedCheckout() { 
        //                //        Exclude = new PaymentProductFilter() { 
        //                //            Groups = null,
        //                //            Products = null
        //                //        },
        //                //        RestrictTo = new PaymentProductFilter() { 
        //                //            Groups = null,
        //                //            Products = null
        //                //        },
        //                //        TokensOnly = null
        //                //    },
        //                //    ReturnCancelState = null,
        //                //    ReturnUrl = null,
        //                //      ShowResultPage = false,
        //                //    Tokens = "",
        //                //    ValidateShoppingCart = false,
        //                Variant = "100",
        //                Locale = "en_BE"
        //            },
        //            //EInvoicePaymentMethodSpecificInput = new EInvoicePaymentMethodSpecificInputBase() { 
        //            //     PaymentProductId = 1,
        //            //RequiresApproval = null
        //            //},
        //            //FraudFields = new FraudFields() { 
        //            //AddressesAreIdentical = false,
        //            //BlackListData = "",
        //            //CardOwnerAddress = null,
        //            //CustomerIpAddress = "",
        //            //DefaultFormFill = "",
        //            //DeviceFingerprintActivated = "",
        //            //DeviceFingerprintTransactionId = "",
        //            //GiftCardType = "",
        //            //GiftMessage = "",
        //            //HasForgottenPwd = "",
        //            //HasPassword = "",
        //            //IsPreviousCustomer = "",
        //            //OrderTimezone = "",
        //            //ShipComments = "",
        //            //ShipmentTrackingNumber = "",
        //            //ShippingDetails = "",
        //            //UserData = "",
        //            //Website = null
        //            //},
        //            //MobilePaymentMethodSpecificInput = new MobilePaymentMethodSpecificInputHostedCheckout() { 
        //            //     PaymentProductId = null,
        //            //     PaymentProduct320SpecificInput = new MobilePaymentProduct320SpecificInputHostedCheckout() { 
        //            //          MerchantName = "Merchant 1069",
        //            //          //MerchantOrigin = ""
        //            //     }
        //            //},
        //            //RedirectPaymentMethodSpecificInput = new RedirectPaymentMethodSpecificInputBase() { 
        //            //ExpirationPeriod = null,
        //            //PaymentProduct840SpecificInput = new RedirectPaymentProduct840SpecificInputBase() { 
        //            //    AddressSelectionAtPayPal = null,
        //            //},
        //            //RecurringPaymentSequenceIndicator = "",
        //            //RequiresApproval = null,
        //            //Token = "e1831cec-bc9a-47d9-bf93-4bbcdaebe299",
        //            //Tokenize = true,
        //            //    PaymentProductId = 1
        //            //}
        //            //,SepaDirectDebitPaymentMethodSpecificInput = new SepaDirectDebitPaymentMethodSpecificInputBase() { 
        //            //PaymentProduct771SpecificInput = new SepaDirectDebitPaymentProduct771SpecificInputBase() { 
        //            //        //ExistingUniqueMandateReference = "",
        //            //        Mandate = new Connect.Sdk.Domain.Mandates.Definitions.CreateMandateBase() { 
        //            //            //Alias = "",
        //            //            Customer = new Connect.Sdk.Domain.Mandates.Definitions.MandateCustomer() { 
        //            //                //BankAccountIban = "",
        //            //                CompanyName = "DXC",
        //            //                //MandateAddress = new Connect.Sdk.Domain.Mandates.Definitions.MandateAddress() { 
        //            //                //    City = "",
        //            //                //    CountryCode = "",
        //            //                //    HouseNumber = "",
        //            //                //    Street = "",
        //            //                //    Zip = ""
        //            //                //},
        //            //                //Account = new CustomerAccount() { },
        //            //                //AccountType = "",
        //            //                //BillingAddress = new Address() { },
        //            //                //CompanyInformation = new CompanyInformation() { },
        //            //                //ContactDetails = new ContactDetails() { },
        //            //                //Device = new CustomerDevice() { },
        //            //                //FiscalNumber = "",
        //            //                //IsPreviousCustomer = null,
        //            //                //Locale = "",
        //            //                //MerchantCustomerId = "",
        //            //                //PersonalInformation = new PersonalInformation() { 
        //            //                //    DateOfBirth = "",
        //            //                //    Gender = "",
        //            //                //    Name = new PersonalName() { 
        //            //                //        FirstName = "",
        //            //                //        Surname = "",
        //            //                //        SurnamePrefix = "",
        //            //                //        Title = ""
        //            //                //    }
        //            //                //},
        //            //                //ShippingAddress = new AddressPersonal() { 
        //            //                //    AdditionalInfo = "",
        //            //                //    City = "",
        //            //                //    CountryCode = "",
        //            //                //    Name = "",
        //            //                //    HouseNumber = "",
        //            //                //    State = "",
        //            //                //    StateCode = "",
        //            //                //    Street = "",
        //            //                //    Zip = ""
        //            //                //},
        //            //                //VatNumber = ""
        //            //            },
        //            //            //CustomerReference = "",
        //            //            //Language = "",
        //            //            //RecurrenceType = "",
        //            //            //SignatureType = "",
        //            //            //UniqueMandateReference = ""
        //            //        }
        //            //    }
        //            //}
        //        }); ;

        //        hostedCheckoutResponse.PartialRedirectUrl = "https://payment." + hostedCheckoutResponse.PartialRedirectUrl;
        //        return hostedCheckoutResponse;
        //    }
        //}


        //[HttpGet]
        //[Route("CreatePayment")]
        //public async Task<CreatePaymentResponse> CreatePayment()
        //{
        //    using (Client client = Factory.CreateClient(this.API_Key_ID, this.Secret_API_Key))
        //    {
        //        MerchantClient merchantClient = client.Merchant(this.MerchantId);
        //        PaymentsClient paymentClient = merchantClient.Payments();
        //        var paymentResponse = await paymentClient.Create(
        //        new CreatePaymentRequest()
        //        {
        //            Order = new Order()
        //            {
        //                AmountOfMoney = new AmountOfMoney()
        //                {
        //                    Amount = 1000,
        //                    CurrencyCode = "EUR"
        //                },
        //                Customer = new Customer()
        //                {
        //                    CompanyInformation = new CompanyInformation()
        //                    {
        //                        Name = "Acme Labs",
        //                        VatNumber = "1234AB5678CD"
        //                    },
        //                    MerchantCustomerId = "1069",
        //                    IsPreviousCustomer = null,
        //                    //ShippingAddress = new AddressPersonal() { 
        //                    //    AdditionalInfo = "",
        //                    //    City = "",
        //                    //    CountryCode = "",
        //                    //    HouseNumber = "",
        //                    //    Name = "",
        //                    //    State = "",
        //                    //    StateCode = "",
        //                    //    Street = "",
        //                    //    Zip = ""
        //                    //},
        //                    Account = new CustomerAccount()
        //                    {
        //                        Authentication = new CustomerAccountAuthentication()
        //                        {
        //                            Method = "",
        //                            UtcTimestamp = ""
        //                        }
        //                    },
        //                    AccountType = "none",
        //                    BillingAddress = new Address()
        //                    {
        //                        AdditionalInfo = "b",
        //                        City = "Monument Valley",
        //                        CountryCode = "US",
        //                        HouseNumber = "13",
        //                        State = "Utah",
        //                        //StateCode = "",
        //                        Street = "Desertroad",
        //                        Zip = "84536"
        //                    },
        //                    ContactDetails = new ContactDetails()
        //                    {
        //                        EmailAddress = "wile.e.coyote@acmelabs.com",
        //                        FaxNumber = "+1234567891",
        //                        MobilePhoneNumber = "+1234567890",
        //                        PhoneNumber = "+1234567890"
        //                        //EmailMessageType = "",
        //                        //,WorkPhoneNumber = ""
        //                    },
        //                    Device = new CustomerDevice()
        //                    {
        //                        AcceptHeader = "texthtml,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
        //                        BrowserData = new BrowserData()
        //                        {
        //                            ColorDepth = null,
        //                            InnerHeight = "",
        //                            InnerWidth = "",
        //                            JavaEnabled = null,
        //                            JavaScriptEnabled = null,
        //                            ScreenHeight = "",
        //                            ScreenWidth = ""
        //                        },
        //                        DefaultFormFill = "",
        //                        DeviceFingerprintTransactionId = "",
        //                        IpAddress = "123.123.123.123",
        //                        Locale = "en-US",
        //                        TimezoneOffsetUtcMinutes = "420",
        //                        UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_4) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/12.1 Safari/605.1.15"
        //                    },
        //                    FiscalNumber = "",
        //                    Locale = "",
        //                    PersonalInformation = new PersonalInformation()
        //                    {
        //                        DateOfBirth = "19490917",
        //                        Gender = "male",
        //                        Name = new PersonalName()
        //                        {
        //                            FirstName = "Jayden",
        //                            Surname = "White",
        //                            SurnamePrefix = "",
        //                            Title = "Mr."
        //                        }
        //                    }
        //                },
        //                References = new OrderReferences()
        //                {
        //                    Descriptor = "Fast and Furry-ous",
        //                    InvoiceData = new OrderInvoiceData()
        //                    {
        //                        AdditionalData = "",
        //                        InvoiceDate = "20140306191500",
        //                        InvoiceNumber = "000000123",
        //                        TextQualifiers = { "", "" }
        //                    },
        //                    MerchantOrderId = 123456,
        //                    MerchantReference = "Merchant 1069"
        //                },
        //                Shipping = new Shipping()
        //                {
        //                    Address = new AddressPersonal()
        //                    {
        //                        AdditionalInfo = "",
        //                        City = "",
        //                        CountryCode = "",
        //                        HouseNumber = "",
        //                        Name = new PersonalName()
        //                        {
        //                            FirstName = "Jayden",
        //                            Surname = "White",
        //                            SurnamePrefix = "",
        //                            Title = "Mr."
        //                        },
        //                        State = "",
        //                        StateCode = "",
        //                        Street = "",
        //                        Zip = ""
        //                    },
        //                    AddressIndicator = "",
        //                    Comments = "",
        //                    EmailAddress = "",
        //                    FirstUsageDate = "",
        //                    IsFirstUsage = null,
        //                    TrackingNumber = "",
        //                    Type = ""
        //                },
        //                ShoppingCart = new ShoppingCart()
        //                {
        //                    AmountBreakdown = {
        //                        new AmountBreakdown() {
        //                            Amount = null,
        //                            Type  = ""
        //                        },
        //                        new AmountBreakdown() {
        //                            Amount = null,
        //                            Type  = ""
        //                        },
        //                        new AmountBreakdown() {
        //                            Amount = null,
        //                            Type  = ""
        //                        }
        //                    },
        //                    GiftCardPurchase = new GiftCardPurchase()
        //                    {
        //                        AmountOfMoney = new AmountOfMoney()
        //                        {
        //                            Amount = 1000,
        //                            CurrencyCode = "EUR"
        //                        }
        //                    },
        //                    IsPreOrder = null,
        //                    Items = { new LineItem() {
        //                            AmountOfMoney = new AmountOfMoney(){
        //                                Amount = 10,
        //                                CurrencyCode = "EUR"
        //                            },
        //                            InvoiceData = new LineItemInvoiceData(){

        //                            },
        //                            Level3InterchangeInformation = new LineItemLevel3InterchangeInformation(){
        //                                DiscountAmount = null,
        //                                LineAmountTotal = null,
        //                                ProductCode = "",
        //                                ProductPrice = null,
        //                                ProductType = "",
        //                                Quantity = null,
        //                                TaxAmount = null,
        //                                Unit = ""
        //                            },
        //                            OrderLineDetails = new OrderLineDetails(){
        //                                ProductCategory = "",
        //                                DiscountAmount= null,
        //                                GoogleProductCategoryId = null,
        //                                LineAmountTotal = null,
        //                                ProductCode = "",
        //                                ProductName = "",
        //                                ProductPrice = null,
        //                                ProductType = "",
        //                                Quantity = null,
        //                                TaxAmount = null,
        //                                Unit = ""
        //                            }
        //                        }
        //                    },
        //                    PreOrderItemAvailabilityDate = ""
        //                }
        //            },
        //            CardPaymentMethodSpecificInput = new CardPaymentMethodSpecificInput()
        //            {
        //                AuthorizationMode = "PRE_AUTHORIZATION",
        //                //InitialSchemeTransactionId
        //                Recurring = new CardRecurrenceDetails()
        //                {
        //                    RecurringPaymentSequenceIndicator = ""
        //                },
        //                Card = new Card()
        //                {
        //                    CardholderName = "Wile E. Coyote",
        //                    CardNumber = "4567350000427977",
        //                    Cvv = "123",
        //                    ExpiryDate = "1220",
        //                    IssueNumber = ""
        //                },
        //                ThreeDSecure = new ThreeDSecure()
        //                {
        //                    AuthenticationFlow = "browser",
        //                    ChallengeCanvasSize = "600x400",
        //                    ChallengeIndicator = "challenge-requested",
        //                    ExternalCardholderAuthenticationData = new ExternalCardholderAuthenticationData()
        //                    {
        //                        Cavv = "",
        //                        CavvAlgorithm = "",
        //                        DirectoryServerTransactionId = "",
        //                        Eci = null,
        //                        ThreeDSecureVersion = "",
        //                        ThreeDServerTransactionId = "",
        //                        ValidationResult = "",
        //                        Xid = ""
        //                    },
        //                },
        //                IsRecurring = true,
        //                PaymentProductId = 1,
        //                TransactionChannel = "ECOMMERCE",

        //            }

        //        }, null);

        //        return paymentResponse;
        //    }
        //}
        //// POST api/values
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/values/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
