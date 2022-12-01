﻿using Hub.Services;

namespace Hub;

public class App
{
    private readonly IDayService _dayService;

    public App(IDayService dayService)
    {
        _dayService = dayService;
    }

    public async Task Run(string[] args)
    {
        await _dayService.Day1();
    }
}