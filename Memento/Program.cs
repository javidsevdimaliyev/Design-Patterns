
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        TextEditor texteditor = new TextEditor();
        TextEditorCaretaker caretaker = new TextEditorCaretaker();

        texteditor.Write("Hello");
        caretaker.SaveMemento(texteditor.Save());
        texteditor.Write(" World!");
        caretaker.SaveMemento(texteditor.Save());
        texteditor.Write(" I am Javid");
        caretaker.SaveMemento(texteditor.Save());
        texteditor.Write(" and I am Developer");
        caretaker.SaveMemento(texteditor.Save());

        Console.WriteLine($"Current Content: {texteditor.Content}");  

        texteditor.Restore(caretaker.GetMemento());
        Console.WriteLine($"After Undo 1: {texteditor.Content}"); 

        texteditor.Restore(caretaker.GetMemento());
        Console.WriteLine($"After Undo 2: {texteditor.Content}");

        texteditor.Restore(caretaker.GetMemento());
        Console.WriteLine($"After Undo 3: {texteditor.Content}");
    }
}

// Originator Class: Keeps current state and creates memento
public class TextEditor
{
    public string Content { get; set; }

    public TextEditorMemento Save()
    {
        return new TextEditorMemento(Content);
    }

    public void Restore(TextEditorMemento memento)
    {
        Content = memento.Content;
    }

    public void Write(string text)
    {
        Content += text;
    }

    public void Undo()
    {
        // A simple undo operation. Deletes the last character.
        if (Content.Length > 0)
        {
            Content = Content.Substring(0, Content.Length - 1);
        }
    }
}


// Caretaker class: Saves Mementos
public class TextEditorCaretaker
{
    private int i = 1;
    private List<TextEditorMemento> _mementos = new();

    public void SaveMemento(TextEditorMemento memento)
    {
        _mementos.Add(memento);
    }

    public TextEditorMemento GetMemento()
    {
        i++;
        if (i >= 0 && i <= _mementos.Count)
        {
            return _mementos[_mementos.Count-i];
        }
        return null;
    }
}

// Memento Class: Stores past state
public class TextEditorMemento
{
    public string Content { get; private set; }

    public TextEditorMemento(string content)
    {
        Content = content;
    }
}





