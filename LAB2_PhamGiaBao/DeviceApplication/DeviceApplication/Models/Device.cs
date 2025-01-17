using System;
using System.ComponentModel.DataAnnotations;

namespace DeviceApplication.Models
{
	public class Device
	{
		public int Id { get; set; }
		public string? Name { get; set; }

		public int CategoryId { get; set; }

		public Category? Category { get; set; }

		public decimal Price { get; set; }
		public string? Status { get; set; }

		[DataType(DataType.Date)]
		public DateTime DateOfEntry { get; set; }
	}
}
