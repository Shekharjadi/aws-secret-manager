namespace aws_secret_manager.Models;
 public class Document
    {
        public int DocumentId { get; set; }          // Primary Key
        public string DocumentName { get; set; }     // File / Document name
        public string DocumentType { get; set; }     // PDF, DOCX, XML
        public long DocumentSize { get; set; }       // Size in bytes
        public string CreatedBy { get; set; }        // User who uploaded
        public DateTime CreatedDate { get; set; }    // Created timestamp
        public bool IsActive { get; set; }            // Soft delete flag
    }