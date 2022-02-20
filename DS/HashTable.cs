public struct KeyValue<K, V>
{
    public K Key { get; set; }
    public V Value { get; set; }
}

public class HashTable
{
    private readonly int size;
    private readonly LinkedList<KeyValue<dynamic,dynamic>>[] items;

    public HashTable(int size)
    {
        this.size = size;
        items = new LinkedList<KeyValue<dynamic,dynamic>>[size];
    }

    protected int GetArrayPosition(dynamic key)
    {
        int position = key.GetHashCode() % size;
        return Math.Abs(position);
    }

    public dynamic Find(dynamic key)
    {
        int position = GetArrayPosition(key);
        LinkedList<KeyValue<dynamic, dynamic>> linkedList = GetLinkedList(position);
        foreach (KeyValue<dynamic,dynamic> item in linkedList)
        {
            if (item.Key.Equals(key))
            {
                return item.Value;
            }
        }

        return default(dynamic);
    }

    public void Add(dynamic key, dynamic value)
    {
        int position = GetArrayPosition(key);
        LinkedList<KeyValue<dynamic, dynamic>> linkedList = GetLinkedList(position);
        KeyValue<dynamic, dynamic> item = new KeyValue<dynamic, dynamic>() { Key = key, Value = value };
        linkedList.AddLast(item);
    }

    public void Remove(dynamic key)
    {
        int position = GetArrayPosition(key);
        LinkedList<KeyValue<dynamic, dynamic>> linkedList = GetLinkedList(position);
        bool itemFound = false;
        KeyValue<dynamic, dynamic> foundItem = default(KeyValue<dynamic, dynamic>);
        foreach (KeyValue<dynamic,dynamic> item in linkedList)
        {
            if (item.Key.Equals(key))
            {
                itemFound = true;
                foundItem = item;
            }
        }

        if (itemFound)
        {
            linkedList.Remove(foundItem);
        }
    }

    protected LinkedList<KeyValue<dynamic, dynamic>> GetLinkedList(int position)
    {
        LinkedList<KeyValue<dynamic, dynamic>> linkedList = items[position];
        if (linkedList == null)
        {
            linkedList = new LinkedList<KeyValue<dynamic, dynamic>>();
            items[position] = linkedList;
        }

        return linkedList;
    }
}

/* Testing
HashTable hash = new HashTable(20);

hash.Add("1", "item 1");
hash.Add(123, '2');
hash.Add("dsfdsdsd", "sadsadsadsad");

var one = hash.Find("1");
var two = hash.Find(123);
string dsfdsdsd = hash.Find("dsfdsdsd");
hash.Remove("1");
*/

/* Reference
https://stackoverflow.com/questions/625947/what-is-an-example-of-a-hashtable-implementation-in-c
*/
