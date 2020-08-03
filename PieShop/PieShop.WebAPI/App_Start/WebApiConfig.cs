using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Ingenico.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            #region TokenController
            config.Routes.MapHttpRoute(
                name: "GetToken",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "Token", action = "GetToken" });

            config.Routes.MapHttpRoute(
                name: "CreateToken",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "Token", action = "CreateToken" });
            #endregion

            #region CheckoutController
            config.Routes.MapHttpRoute(
                 name: "CreateHostedCheckout",
                 routeTemplate: "api/{controller}/{id}",
                 defaults: new { controller = "Checkout", action = "CreateHostedCheckout" });

            config.Routes.MapHttpRoute(
               name: "GetHostedCheckoutStatus",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { controller = "Checkout", action = "GetHostedCheckoutStatus" });
            #endregion

            #region PaymentController
            config.Routes.MapHttpRoute(
                name: "CreatePayment",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "Payment", action = "CreatePayment" });
            #endregion

            #region SessionController
            config.Routes.MapHttpRoute(
                name: "CreateSession",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "Session", action = "CreateSession" });
            #endregion

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
