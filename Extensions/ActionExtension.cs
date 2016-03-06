using System;

public static class ActionExtension
{
    public static void Emit(this Action action)
    {
        if (action != null)
            action();
    }

    public static void Emit<T>(this Action<T> action, T arg)
    {
        if (action != null)
            action(arg);
    }

    public static void Emit<T,E>(this Action<T,E> action, T arg0, E arg1)
    {
        if (action != null)
            action(arg0, arg1);
    }

    public static void Emit<T,E,P>(this Action<T,E,P> action, T arg0, E arg1, P arg2)
    {
        if (action != null)
            action(arg0, arg1, arg2);
    }
}

