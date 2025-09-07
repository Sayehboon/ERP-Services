using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.UomConversions.Queries.GetUomConversionById;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت تبدیل واحد اندازه‌گیری بر اساس شناسه
/// </summary>
public sealed class GetUomConversionByIdQueryHandler : IRequestHandler<GetUomConversionByIdQuery, UomConversionDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت تبدیل واحد اندازه‌گیری بر اساس شناسه
    /// </summary>
    public GetUomConversionByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// اجرای پرس‌وجو
    /// </summary>
    public async Task<UomConversionDto?> Handle(GetUomConversionByIdQuery request, CancellationToken cancellationToken)
    {
        var uomConversion = await _context.UomConversions
            .Include(uc => uc.FromUom)
            .Include(uc => uc.ToUom)
            .FirstOrDefaultAsync(uc => uc.Id == request.Id, cancellationToken);

        if (uomConversion == null)
        {
            return null;
        }

        var dto = _mapper.Map<UomConversionDto>(uomConversion);
        dto.FromUomName = uomConversion.FromUom?.Name;
        dto.FromUomCode = uomConversion.FromUom?.Code;
        dto.FromUomSymbol = uomConversion.FromUom?.Symbol;
        dto.ToUomName = uomConversion.ToUom?.Name;
        dto.ToUomCode = uomConversion.ToUom?.Code;
        dto.ToUomSymbol = uomConversion.ToUom?.Symbol;
        return dto;
    }
}
