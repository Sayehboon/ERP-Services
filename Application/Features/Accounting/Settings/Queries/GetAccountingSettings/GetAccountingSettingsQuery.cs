namespace Dinawin.Erp.Application.Features.Accounting.Settings.Queries.GetAccountingSettings;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// کوئری دریافت تنظیمات حسابداری
/// Query to get accounting settings
/// </summary>
public record GetAccountingSettingsQuery(string BusinessId = "default") : IRequest<AccountingSettingsDto>;

/// <summary>
/// DTO تنظیمات حسابداری
/// Accounting settings DTO
/// </summary>
public class AccountingSettingsDto
{
    /// <summary>ارز پیش‌فرض</summary>
    public string DefaultCurrency { get; set; } = "IRR";
    /// <summary>نرخ مالیات بر ارزش افزوده</summary>
    public decimal VatRate { get; set; } = 9;
    /// <summary>نرخ مالیات علی‌الحساب</summary>
    public decimal WithholdingRate { get; set; } = 3;
    /// <summary>کد حساب مالیات بر ارزش افزوده</summary>
    public string VatAccountCode { get; set; }
    /// <summary>کد حساب مالیات علی‌الحساب</summary>
    public string WithholdingAccountCode { get; set; }
    /// <summary>کد حساب سود تفاوت ارز</summary>
    public string FxGainAccountCode { get; set; }
    /// <summary>کد حساب زیان تفاوت ارز</summary>
    public string FxLossAccountCode { get; set; }
    /// <summary>شناسه حساب سود انباشته</summary>
    public Guid? RetainedEarningsAccountId { get; set; }
}

/// <summary>
/// هندلر کوئری دریافت تنظیمات حسابداری
/// Handler for accounting settings query
/// </summary>
public class GetAccountingSettingsQueryHandler(IApplicationDbContext db) : IRequestHandler<GetAccountingSettingsQuery, AccountingSettingsDto>
{
    public async Task<AccountingSettingsDto> Handle(GetAccountingSettingsQuery request, CancellationToken cancellationToken)
    {
        // Settings are stored in key-value system settings with category = "accounting"
        var settings = await db.SystemSettings.AsNoTracking()
            .Where(s => s.Category == "accounting" && s.BusinessId == request.BusinessId)
            .ToListAsync(cancellationToken);

        AccountingSettingsDto dto = new();
        foreach (var s in settings)
        {
            switch (s.Key)
            {
                case "default_currency": dto.DefaultCurrency = s.Value ?? dto.DefaultCurrency; break;
                case "vat_rate": if (decimal.TryParse(s.Value, out var vr)) dto.VatRate = vr; break;
                case "withholding_rate": if (decimal.TryParse(s.Value, out var wr)) dto.WithholdingRate = wr; break;
                case "vat_account_code": dto.VatAccountCode = s.Value; break;
                case "withholding_account_code": dto.WithholdingAccountCode = s.Value; break;
                case "fx_gain_account_code": dto.FxGainAccountCode = s.Value; break;
                case "fx_loss_account_code": dto.FxLossAccountCode = s.Value; break;
                case "retained_earnings_account_id": if (Guid.TryParse(s.Value, out var re)) dto.RetainedEarningsAccountId = re; break;
            }
        }

        return dto;
    }
}


