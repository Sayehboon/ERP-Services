using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemSettings.Queries.GetSystemSettingByKey;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت تنظیم سیستم بر اساس کلید
/// </summary>
public sealed class GetSystemSettingByKeyQueryHandler : IRequestHandler<GetSystemSettingByKeyQuery, SystemSettingDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت تنظیم سیستم بر اساس کلید
    /// </summary>
    public GetSystemSettingByKeyQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// اجرای پرس‌وجو
    /// </summary>
    public async Task<SystemSettingDto> Handle(GetSystemSettingByKeyQuery request, CancellationToken cancellationToken)
    {
        var systemSetting = await _context.SystemSettings
            .FirstOrDefaultAsync(ss => ss.Key == request.Key, cancellationToken);

        if (systemSetting == null)
        {
            return null;
        }

        return _mapper.Map<SystemSettingDto>(systemSetting);
    }
}
