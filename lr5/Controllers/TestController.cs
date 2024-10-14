using Microsoft.AspNetCore.Mvc;
using System;

public class TestController : ControllerBase
{
    [HttpGet("test-argument-exception")]
    public IActionResult TestArgumentException()
    {
        throw new ArgumentException("Це тестове виключення ArgumentException");
    }

    [HttpGet("test-not-implemented")]
    public IActionResult TestNotImplementedException()
    {
        throw new NotImplementedException("Ця функція ще не реалізована");
    }
}

