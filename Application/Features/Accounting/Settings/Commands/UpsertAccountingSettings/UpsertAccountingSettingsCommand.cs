namespace Dinawin.Erp.Application.Features.Accounting.Settings.Commands.UpsertAccountingSettings;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// فرمان ایجاد/به‌روزرسانی تنظیمات حسابداری
/// Upsert accounting settings command
/// </summary>
public record UpsertAccountingSettingsCommand(
    string BusinessId,
    string DefaultCurrency,
    decimal VatRate,
    decimal WithholdingRate,
    string VatAccountCode,
    string WithholdingAccountCode,
    string FxGainAccountCode,
    string FxLossAccountCode,
    Guid? RetainedEarningsAccountId
) : IRequest<bool>;

/// <summary>
/// هندلر فرمان ایجاد/به‌روزرسانی تنظیمات حسابداری
/// Handler for UpsertAccountingSettingsCommand
/// </summary>
public class UpsertAccountingSettingsCommandHandler(IApplicationDbContext db) : IRequestHandler<UpsertAccountingSettingsCommand, bool>
{
    public async Task<bool> Handle(UpsertAccountingSettingsCommand request, CancellationToken cancellationToken)
    {
        // Store as key-value system settings under category = "accounting"
        async Task Upsert(string key, string value)
        {
            var ss = await db.SystemSettings.FirstOrDefaultAsync(
                s => s.Category == "accounting" && s.Key == key && s.BusinessId == request.BusinessId,
                cancellationToken);
            if (ss == null)
            {
                db.SystemSettings.Add(new Dinawin.Erp.Domain.Entities.Systems.SystemSetting
                {
                    Id = Guid.NewGuid(),
                    Category = "accounting",
                    Key = key,
                    Value = value,
                    BusinessId = request.BusinessId
                });
            }
            else
            {
                ss.Value = value;
            }
        }

        await Upsert("default_currency", request.DefaultCurrency);
        await Upsert("vat_rate", request.VatRate.ToString());
        await Upsert("withholding_rate", request.WithholdingRate.ToString());
        await Upsert("vat_account_code", request.VatAccountCode);
        await Upsert("withholding_account_code", request.WithholdingAccountCode);
        await Upsert("fx_gain_account_code", request.FxGainAccountCode);
        await Upsert("fx_loss_account_code", request.FxLossAccountCode);
        await Upsert("retained_earnings_account_id", request.RetainedEarningsAccountId?.ToString());

        await db.SaveChangesAsync(cancellationToken);
        return true;
    }
}


