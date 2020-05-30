namespace LinkedHash
{
	class LinkedHash
	{
		public long Key { get; set; }
		public long Value { get; set; }
		public LinkedHash Next { get; set; }

		public LinkedHash(long key, long value)
		{
			Key = key;
			Value = value;
			Next = null;
		}
	}
}
