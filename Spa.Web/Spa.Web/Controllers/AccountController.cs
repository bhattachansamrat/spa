using Spa.Data.Infrastructure;
using Spa.Data.Repository;
using Spa.Entities;
using Spa.Services.Abstract;
using Spa.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Spa.Web.Models;

namespace Spa.Web.Controllers
{
    [RoutePrefix("/api/account")]
    public class AccountController : ApiBaseController
    {
        private readonly IMembershipService membershipService;

        public AccountController(IEntityBaseRepository<Error> error, IUnitOfWork unitOfWork,
            IMembershipService membershipService)
            :base(error, unitOfWork)
        {
            this.membershipService = membershipService;
        }

        [Route("login")]
        public HttpResponseMessage Login(HttpRequestMessage request, LoginViewModel loginModel)
        {
            return CreateResponse(request, () => {
                HttpResponseMessage response = null;

                var membershipContext = membershipService.ValidateUser(loginModel.UserName, loginModel.Password);
                if(!ModelState.IsValid)
                {
                    return request.CreateResponse(HttpStatusCode.OK, new { success= false });
                }
                if(null == membershipContext.User)
                {
                    return request.CreateResponse(HttpStatusCode.OK, new { success = false });
                }
                return request.CreateResponse(HttpStatusCode.OK, new { success = true });
            });
        }
    }
}
