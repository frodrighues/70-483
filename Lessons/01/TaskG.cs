﻿using System;
using Rhino.Mocks;
using Xunit;

namespace Lessons._01
{
    /// <summary>
    /// Complete the tests without implementation according to their names.
    /// Run the tests and check if the implementation of Thermostat is correct. If not, fix it.
    /// </summary>
    public class TaskG
    {
        private readonly ICurrentTemperatureProvider _currentTemperatureProvider;
        private readonly ITemperatureSettingsProvider _temperatureSettingsProvider;
        private readonly IHeater _heater;
        private readonly Thermostat _thermostat;

        public TaskG()
        {
            _currentTemperatureProvider = MockRepository.GenerateMock<ICurrentTemperatureProvider>();
            _temperatureSettingsProvider = MockRepository.GenerateMock<ITemperatureSettingsProvider>();
            _heater = MockRepository.GenerateMock<IHeater>();

            _thermostat = new Thermostat(_currentTemperatureProvider, _temperatureSettingsProvider, _heater);
        }

        [Fact]
        public void Check_WhenTemperatureIsLowerAndHeaterIsNotStarted_ShouldStartHeater()
        {
            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(19);
            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);

            _thermostat.Check();

            _heater.AssertWasCalled(x => x.Start());
        }

        [Fact]
        public void Check_WhenTemperatureIsLowerAndHeaterIsStarted_ShouldNotStartHeater()
        {
            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(19);
            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);

            _thermostat.Check();

            Assert.Equal(true, !_heater.IsStarted);
        }

        [Fact]
        public void Check_WhenTemperatureIsAsRequestedAndHeaterIsNotStarted_ShouldNotStartHeater()
        {
            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(20);
            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);

            _thermostat.Check();

            Assert.Equal(true, !_heater.IsStarted);
        }

        [Fact]
        public void Check_WhenTemperatureIsAsRequestedAndHeaterIsStarted_ShouldStopHeater()
        {
            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(20);
            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);
            _heater.IsStarted = true;

            _thermostat.Check();

            _heater.AssertWasCalled(x => x.Stop());
        }

        [Fact]
        public void Check_WhenTemperatureIsHigherAndHeaterIsStarted_ShouldStopHeater()
        {
            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(25);
            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);

            _thermostat.Check();

            _heater.AssertWasCalled(x => x.Stop());
        }

        [Fact]
        public void Check_WhenTemperatureIsHigherAndHeaterIsNotStarted_ShouldNotStopHeater()
        {
            _currentTemperatureProvider.Stub(x => x.GetTemperature()).Return(25);
            _temperatureSettingsProvider.Stub(x => x.GetRequestedTemperature()).Return(20);

            _thermostat.Check();

            _heater.AssertWasNotCalled(x => x.Stop());
        }
    }

    public class Thermostat
    {
        private readonly ICurrentTemperatureProvider _currentTemperatureProvider;
        private readonly ITemperatureSettingsProvider _temperatureSettingsProvider;
        private readonly IHeater _heater;

        public Thermostat(
            ICurrentTemperatureProvider currentTemperatureProvider, 
            ITemperatureSettingsProvider temperatureSettingsProvider, 
            IHeater heater)
        {
            _currentTemperatureProvider = currentTemperatureProvider;
            _temperatureSettingsProvider = temperatureSettingsProvider;
            _heater = heater;
        }

        public void Check()
        {
            var currentTemperature = _currentTemperatureProvider.GetTemperature();
            var requestedTemperature = _temperatureSettingsProvider.GetRequestedTemperature();

            if (currentTemperature >= requestedTemperature && _heater.IsStarted)
            {
                _heater.Stop();
                _heater.IsStarted = false;
            }

            if (currentTemperature <= requestedTemperature && !_heater.IsStarted)
            {
                _heater.Start();
                _heater.IsStarted = true;
            }
        }
    }

    public interface IHeater
    {
        bool IsStarted { get; set; }

        void Start();
        void Stop();
    }

    public interface ITemperatureSettingsProvider
    {
        decimal GetRequestedTemperature();
    }

    public interface ICurrentTemperatureProvider
    {
        decimal GetTemperature();
    }
}