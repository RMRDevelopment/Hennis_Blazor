using Hennis_Models.ViewModels;

namespace Hennis_Admin.Service.IService
{
    public interface IPaystubService
    {
        Task<string> ProcessPdf(PaystubModel model);
    }
}
