using Gatlin.WCF.Contracts.Model;
using System.ServiceModel;

namespace Gatlin.WCF.Contracts
{
    [ServiceContract]
    public interface IBaseService
    {
        [OperationContract]
        BaseModel Get(BaseParam param);

        [OperationContract]
        int Add(BaseModel model);

        [OperationContract]
        void Update(BaseModel model);

        [OperationContract]
        void Delete(int id);
    }
}
