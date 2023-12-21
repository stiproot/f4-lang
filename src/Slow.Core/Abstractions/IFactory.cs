namespace Slow.Core.Abstractions;

public interface IFactory<out TProduct>
{
    TProduct Create();
}

public interface IFactory<in TConfiguration, out TProduct>
{
    TProduct Create(TConfiguration configuration);
}