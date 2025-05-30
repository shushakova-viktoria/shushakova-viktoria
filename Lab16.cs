/* Задача на указатели. Небходимо, используя указатели сформировать двоичное дерево (бинарное), представляющее собой список взаимодействующих
 * объектов, которые характеризуются идентификационным номером и наименованием. На вход подаются объекты, которые имеют поля: идентификационный 
 * номер и имя. Первый объект: корень дерева. У каждого элемента два указателя. Адрес кладется в указатель На выход бинарное дерево 
 * с двумя указателями. Рассматриваем только добавление, то есть формирование элементов.*/

using System;
using System.Runtime.InteropServices;
public unsafe struct TreeNode
{
    public int Id;
    public string Name;
    public TreeNode* Left;   
    public TreeNode* Right;  

    public TreeNode(int id, string name)
    {
        Id = id;
        Name = name;
        Left = null;
        Right = null;
    }
}

public unsafe class BinaryTree
{
    public TreeNode* Root;

    public void Insert(int id, string name)
    {
        TreeNode* newNode = (TreeNode*)Marshal.AllocHGlobal(sizeof(TreeNode));
        *newNode = new TreeNode(id, name);

        if (Root == null)
        {
            Root = newNode;
            return;
        }

        TreeNode* current = Root;
        while (true)
        {
            if (id < current->Id)
            {
                if (current->Left == null)
                {
                    current->Left = newNode;
                    break;
                }
                else
                {
                    current = current->Left;
                }
            }
            else if (id > current->Id)
            {
                if (current->Right == null)
                {
                    current->Right = newNode;
                    break;
                }
                else
                {
                    current = current->Right;
                }
            }
            else
            {
                current->Name = name;
                Marshal.FreeHGlobal((IntPtr)newNode); 
                break;
            }
        }
    }

    public void PrintInOrder(TreeNode* node)
    {
        if (node != null)
        {
            PrintInOrder(node->Left);
            Console.WriteLine($"ID: {node->Id}, Name: {node->Name}");
            PrintInOrder(node->Right);
        }
    }

    public void FreeTree(TreeNode* node)
    {
        if (node != null)
        {
            FreeTree(node->Left);
            FreeTree(node->Right);
            Marshal.FreeHGlobal((IntPtr)node);
        }
    }
}

public class Program
{
    public static unsafe void Main()
    {
        BinaryTree tree = new BinaryTree();

        tree.Insert(5, "Маша");
        tree.Insert(3, "Наташа");
        tree.Insert(7, "Саша");
        tree.Insert(2, "Вика");
        tree.Insert(4, "Катя");
        tree.Insert(6, "Ксюша");
        tree.Insert(8, "Таня");

        Console.WriteLine("Бинарное дерево (in-order):");
        tree.PrintInOrder(tree.Root);

        tree.FreeTree(tree.Root);
    }
}


