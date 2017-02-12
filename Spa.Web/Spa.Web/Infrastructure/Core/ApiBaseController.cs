using Spa.Data.Infrastructure;
using Spa.Data.Repository;
using Spa.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Spa.Web.Infrastructure.Core
{
    public class ApiBaseController : ApiController
    {
        private IEntityBaseRepository<Error> errorRepository;
        private IUnitOfWork unitOfWork;

        public ApiBaseController(IEntityBaseRepository<Error> errorRepository, IUnitOfWork unitOfWork)
        {
            this.errorRepository = errorRepository;
            this.unitOfWork = unitOfWork;
        }

        protected HttpResponseMessage CreateResponse(HttpRequestMessage request, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;
            try
            {
                response = function.Invoke();
            }
            catch(DbUpdateException ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch(Exception ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            return response;
        }

        private void LogError(Exception ex)
        {
            var error = new Error() {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                DateCreated = DateTime.Now
            };
            errorRepository.Add(error);
            unitOfWork.Commit();
        }
    }
}
