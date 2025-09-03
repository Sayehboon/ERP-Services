using Dinawin.Erp.Application.Features.Accounting.Accounts.Queries.Dtos;
using Dinawin.Erp.Application.Features.Accounting.Accounts.Queries.GetAllAccounts;
using Dinawin.Erp.Application.Features.Accounting.Accounts.Queries.GetAccountsByBusiness;
using Dinawin.Erp.Application.Features.Accounting.Accounts.Commands.CreateAccount;
using Dinawin.Erp.Application.Features.Accounting.Accounts.Commands.UpdateAccountStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

/// <summary>
/// کنترلر حساب‌های دفتر کل (GL)
/// GL Accounts controller
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class AccountsController : ControllerBase
{
	private readonly IMediator _mediator;

	/// <summary>
	/// سازنده کنترلر
	/// Controller constructor
	/// </summary>
	public AccountsController(IMediator mediator)
	{
		_mediator = mediator;
	}

	/// <summary>
	/// لیست حساب‌های فعال
	/// Get active accounts
	/// </summary>
	[HttpGet]
	[ProducesResponseType(typeof(IEnumerable<AccountDto>), 200)]
	public async Task<ActionResult<IEnumerable<AccountDto>>> Get([FromQuery] string? keyword = null)
	{
		var result = await _mediator.Send(new GetAllAccountsQuery(keyword));
		return Ok(result);
	}

	/// <summary>
	/// لیست حساب‌های کسب‌وکار
	/// Get accounts by business
	/// </summary>
	[HttpGet("business/{businessId}")]
	[ProducesResponseType(typeof(IEnumerable<AccountDto>), 200)]
	public async Task<ActionResult<IEnumerable<AccountDto>>> GetByBusiness(string businessId)
	{
		var result = await _mediator.Send(new GetAccountsByBusinessQuery(businessId));
		return Ok(result);
	}

	/// <summary>
	/// ایجاد حساب جدید
	/// Create new account
	/// </summary>
	[HttpPost]
	[ProducesResponseType(typeof(Guid), 201)]
	public async Task<ActionResult<Guid>> Create([FromBody] CreateAccountCommand command)
	{
		var id = await _mediator.Send(command);
		return CreatedAtAction(nameof(Get), new { id }, id);
	}

	/// <summary>
	/// به‌روزرسانی وضعیت حساب
	/// Update account status
	/// </summary>
	[HttpPut("{id}/status")]
	[ProducesResponseType(200)]
	public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] bool isActive)
	{
		var ok = await _mediator.Send(new UpdateAccountStatusCommand(id, isActive));
		if (!ok) return NotFound();
		return Ok();
	}
}
