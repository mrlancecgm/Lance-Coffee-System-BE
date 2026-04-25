using LanceCoffeeSystem.Application.DTOs.Mail;
using System.Threading.Tasks;

namespace LanceCoffeeSystem.Application.Interfaces.Shared
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}