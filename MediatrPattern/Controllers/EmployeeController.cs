using System;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using MediatR;
using MediatrPattern.Dto;
using MediatrPattern.MediatR.Employee.Command;
using MediatrPattern.MediatR.Employee.Query;
using MediatrPattern.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace MediatrPattern.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly INotyfService _noty;

        public EmployeeController(IMediator mediator, INotyfService noty)
        {
            _mediator = mediator;
            _noty = noty;
        }

        public async Task<IActionResult> Index()
            => View(await _mediator.Send(new GetAllEmployeeQuery()));

        public IActionResult New() 
            => View(new EmployeeVm());

        [HttpPost]
        public async Task<IActionResult> New(EmployeeVm vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(vm);
                }

                var dto = new EmployeeDto(vm.FirstName, vm.LastName, vm.Address, vm.Phone, vm.Salary);
                await _mediator.Send(new NewEmployeeCommand(dto));
                _noty.Success("Employee Added");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _noty.Error(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Edit(long id)
        {
            try
            {
                var employee = await _mediator.Send(new GetSingleEmployeeQuery(id));
                var vm = new EmployeeUpdateVm()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Address = employee.Address,
                    Phone = employee.Phone,
                    Salary = employee.Salary,
                    Employee = employee
                };
                return View(vm);
            }
            catch (Exception e)
            {
                _noty.Error(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long id, EmployeeUpdateVm vm)
        {
            try
            {
                var employee = await _mediator.Send(new GetSingleEmployeeQuery(id));
                if (!ModelState.IsValid)
                {
                    vm.Employee = employee;
                    return View(vm);
                }

                var dto = new EmployeeDto(vm.FirstName, vm.LastName, vm.Address, vm.Phone, vm.Salary);
                await _mediator.Send(new UpdateEmployeeCommand(employee, dto));
                _noty.Success("Employee Info Updated");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _noty.Success(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                var employee = await _mediator.Send(new GetSingleEmployeeQuery(id));
                await _mediator.Send(new DeleteEmployeeCommand(employee));
                _noty.Success("Employee Removed");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                _noty.Error(e.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}