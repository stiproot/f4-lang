namespace F4lang.Core.Abstractions;

public interface IObjMapper
{
    TTo Map<TFrom, TTo>(TFrom from);
}
