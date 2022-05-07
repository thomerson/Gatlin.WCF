using Gatlin.WCF.Contracts;
using Gatlin.WCF.Contracts.Model;
using System;
using System.ServiceModel;

namespace Gatlin.WCF.Services
{
    [ServiceBehavior(UseSynchronizationContext = false,
        IncludeExceptionDetailInFaults = true,
        ConcurrencyMode = ConcurrencyMode.Single,
        InstanceContextMode = InstanceContextMode.Single)]
    public class BaseService : IBaseService
    {
        public int Add(BaseModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BaseModel Get(BaseParam param)
        {
            throw new NotImplementedException();
        }

        public void Update(BaseModel model)
        {
            throw new NotImplementedException();
        }
    }
}
