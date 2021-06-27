using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ERP.Data.Models
{
    public partial class ERPContext : DbContext
    {
        public ERPContext()
        {
        }

        public ERPContext(DbContextOptions<ERPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessLevel> AccessLevels { get; set; }
        public virtual DbSet<AccessLevelDesignation> AccessLevelDesignations { get; set; }
        public virtual DbSet<AdminType> AdminTypes { get; set; }
        public virtual DbSet<ApprovalMaster> ApprovalMasters { get; set; }
        public virtual DbSet<Constant> Constants { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentAdmin> DepartmentAdmins { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<FeedbackTopic> FeedbackTopics { get; set; }
        public virtual DbSet<GroupAdmin> GroupAdmins { get; set; }
        public virtual DbSet<GroupMember> GroupMembers { get; set; }
        public virtual DbSet<HelpIndex> HelpIndexes { get; set; }
        public virtual DbSet<HelpSection> HelpSections { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportAccess> ReportAccesses { get; set; }
        public virtual DbSet<ReportCategory> ReportCategories { get; set; }
        public virtual DbSet<ReportFilter> ReportFilters { get; set; }
        public virtual DbSet<ReportMoreInfo> ReportMoreInfos { get; set; }
        public virtual DbSet<ReportRequest> ReportRequests { get; set; }
        public virtual DbSet<ReportSubscription> ReportSubscriptions { get; set; }
        public virtual DbSet<ReportSubscriptionLog> ReportSubscriptionLogs { get; set; }
        public virtual DbSet<TestTable> TestTables { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAction> UserActions { get; set; }
        public virtual DbSet<UserActionType> UserActionTypes { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=rcoedemodb.database.windows.net;Database=PortalDB;User Id=PortalAdmin;Password=Portal@123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AccessLevel>(entity =>
            {
                entity.ToTable("AccessLevel");

                entity.Property(e => e.AccessLevelId).HasColumnName("access_level_id");

                entity.Property(e => e.AccessLevelName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("access_level_name");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<AccessLevelDesignation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccessLevelId).HasColumnName("access_level_id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.DesignationId).HasColumnName("designation_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.AccessLevel)
                    .WithMany(p => p.AccessLevelDesignations)
                    .HasForeignKey(d => d.AccessLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccessLevelDesignations_AccessLevel");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.AccessLevelDesignations)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_AccessLevelDesignations_Departments");
            });

            modelBuilder.Entity<AdminType>(entity =>
            {
                entity.Property(e => e.AdminTypeId).HasColumnName("admin_type_id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.TypeName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("type_name");
            });

            modelBuilder.Entity<ApprovalMaster>(entity =>
            {
                entity.HasKey(e => e.ApprovalId);

                entity.ToTable("Approval_master");

                entity.Property(e => e.ApprovalId).HasColumnName("approval_id");

                entity.Property(e => e.ApprovalUserId).HasColumnName("approval_user_id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ApprovalMasters)
                    .HasForeignKey(d => d.ReportId)
                    .HasConstraintName("FK_Approval_master_Reports");
            });

            modelBuilder.Entity<Constant>(entity =>
            {
                entity.Property(e => e.ConstantId).HasColumnName("constant_id");

                entity.Property(e => e.ConstantName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("constant_name");

                entity.Property(e => e.ConstantValue)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("constant_value");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("department_name");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<DepartmentAdmin>(entity =>
            {
                entity.ToTable("department_admin");

                entity.Property(e => e.DepartmentAdminId).HasColumnName("department_admin_id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.IsAbleToReportRequestAccess).HasColumnName("is_able_to_report_request_access");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsEnableToAddNewReport).HasColumnName("is_enable_to_add_new_report");

                entity.Property(e => e.IsEnableToCrtGroupAdmin).HasColumnName("is_enable_to_crt_group_admin");

                entity.Property(e => e.IsEnableToCrtUserGroups).HasColumnName("is_enable_to_crt_user_groups");

                entity.Property(e => e.IsEnableToCrtUsserRoles).HasColumnName("is_enable_to_crt_usser_roles");

                entity.Property(e => e.LimitToGroupAdmin).HasColumnName("limit_to_group_admin");

                entity.Property(e => e.LimitToUserGroup).HasColumnName("limit_to_user_group");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Feedback1)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("feedback");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Topic)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("topic");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Feedback_Departments");
            });

            modelBuilder.Entity<FeedbackTopic>(entity =>
            {
                entity.ToTable("feedback_topics");

                entity.Property(e => e.FeedbackTopicId).HasColumnName("feedback_topic_id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.FeedbackTopicDesc)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("feedback_topic_desc");

                entity.Property(e => e.FeedbackTopicName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("feedback_topic_name");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.TopicOwnerId).HasColumnName("topic_owner_id");
            });

            modelBuilder.Entity<GroupAdmin>(entity =>
            {
                entity.ToTable("group_admin");

                entity.Property(e => e.GroupAdminId).HasColumnName("group_admin_id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsAbleToReportRequestAccess).HasColumnName("is_able_to_report_request_access");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsEnableToAddNewReport).HasColumnName("is_enable_to_add_new_report");

                entity.Property(e => e.IsEnableToCrtUserGroups).HasColumnName("is_enable_to_crt_user_groups");

                entity.Property(e => e.IsEnableToCrtUserRoles).HasColumnName("is_enable_to_crt_user_roles");

                entity.Property(e => e.LimitToUserGroup).HasColumnName("limit_to_user_group");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.UserGroupId).HasColumnName("user_group_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<GroupMember>(entity =>
            {
                entity.Property(e => e.GroupMemberId).HasColumnName("group_member_id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.UserGroupId).HasColumnName("user_group_Id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.UserGroup)
                    .WithMany(p => p.GroupMembers)
                    .HasForeignKey(d => d.UserGroupId)
                    .HasConstraintName("FK_GroupMembers_UserGroups");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupMembers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupMembers_Users");
            });

            modelBuilder.Entity<HelpIndex>(entity =>
            {
                entity.ToTable("help_indexes");

                entity.Property(e => e.HelpIndexId).HasColumnName("help_index_id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.HelpContent)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("help_content");

                entity.Property(e => e.HelpSectionId).HasColumnName("help_section_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.HelpSection)
                    .WithMany(p => p.HelpIndices)
                    .HasForeignKey(d => d.HelpSectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_help_indexes_help_section");
            });

            modelBuilder.Entity<HelpSection>(entity =>
            {
                entity.ToTable("help_section");

                entity.Property(e => e.HelpSectionId).HasColumnName("help_section_id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.HelpSectionName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("help_section_name");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CognosLink)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("cognos_link");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.HasDataLevelSecurity).HasColumnName("has_data_level_security");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Notes)
                    .IsUnicode(false)
                    .HasColumnName("notes");

                entity.Property(e => e.PbiReportAppId)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("pbi_report_app_id");

                entity.Property(e => e.PbiReportId)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("pbi_report_id");

                entity.Property(e => e.PbiWorkspaceId)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("pbi_workspace_id");

                entity.Property(e => e.ReportDescription)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("report_description");

                entity.Property(e => e.ReportName)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("report_name");

                entity.Property(e => e.ReportPrefix)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("report_prefix");

                entity.Property(e => e.ReportType)
                    .HasColumnName("report_type")
                    .HasComment("1 --> powerBI  2 ---> Cognos");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Reports_ReportCategoryMaster");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reports_Departments");
            });

            modelBuilder.Entity<ReportAccess>(entity =>
            {
                entity.ToTable("ReportAccess");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccessLevelId).HasColumnName("access_level_id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsExportExcel).HasColumnName("is_export_excel");

                entity.Property(e => e.IsExportPdf).HasColumnName("is_export_pdf");

                entity.Property(e => e.IsScreenShot).HasColumnName("is_screen_shot");

                entity.Property(e => e.IsShare).HasColumnName("is_share");

                entity.Property(e => e.IsSubscribe).HasColumnName("is_subscribe");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.TeamId).HasColumnName("team_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.ReportAccesses)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportAccess_Departments");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReportAccesses)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportAccess_Reports");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.ReportAccesses)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportAccess_UserGroups");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReportAccesses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportAccess_Users");
            });

            modelBuilder.Entity<ReportCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK_ReportCategoryMaster");

                entity.ToTable("ReportCategory");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("category_name");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.ReportCategories)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_ReportCategoryMaster_Departments");
            });

            modelBuilder.Entity<ReportFilter>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.FilterKey)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("filter_key");

                entity.Property(e => e.FilterValue)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("filter_value");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReportFilters)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportFilters_Reports");
            });

            modelBuilder.Entity<ReportMoreInfo>(entity =>
            {
                entity.ToTable("ReportMoreInfo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Description)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.Title)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReportMoreInfos)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportMoreInfo_Reports");
            });

            modelBuilder.Entity<ReportRequest>(entity =>
            {
                entity.Property(e => e.ReportRequestId).HasColumnName("report_request_id");

                entity.Property(e => e.ApprovedBy).HasColumnName("approved_by");

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("comments");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.RequestedBy).HasColumnName("requested_by");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReportRequests)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportRequests_Reports");
            });

            modelBuilder.Entity<ReportSubscription>(entity =>
            {
                entity.ToTable("ReportSubscription");

                entity.Property(e => e.ReportSubscriptionId).HasColumnName("report_subscription_id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DateOfMonth)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("date_of_month");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.Frequency)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("frequency");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.SheduledTime).HasColumnName("sheduled_time");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.UseridEmail).HasColumnName("userid_email");

                entity.Property(e => e.Weekday)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("weekday");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReportSubscriptions)
                    .HasForeignKey(d => d.ReportId)
                    .HasConstraintName("FK_ReportSubscription_Reports");

                entity.HasOne(d => d.UseridEmailNavigation)
                    .WithMany(p => p.ReportSubscriptions)
                    .HasForeignKey(d => d.UseridEmail)
                    .HasConstraintName("FK_ReportSubscription_Users");
            });

            modelBuilder.Entity<ReportSubscriptionLog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.GeneratedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("generated_time");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ReportSubscriptionId).HasColumnName("report_subscription_id");

                entity.HasOne(d => d.ReportSubscription)
                    .WithMany(p => p.ReportSubscriptionLogs)
                    .HasForeignKey(d => d.ReportSubscriptionId)
                    .HasConstraintName("FK_ReportSubscriptionLogs_ReportSubscription");
            });

            modelBuilder.Entity<TestTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Test_table");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("password")
                    .IsFixedLength(true);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("username")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.CoworkerId).HasColumnName("coworker_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DepartmentId).HasColumnName("department_id");

                entity.Property(e => e.Designation)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("designation");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.LastName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ReportingManagerId).HasColumnName("reporting_manager_id");

                entity.Property(e => e.Username)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Users_Departments");
            });

            modelBuilder.Entity<UserAction>(entity =>
            {
                entity.ToTable("User_actions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActionDesc)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("action_desc");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date");

                entity.Property(e => e.NewValue)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("new_value");

                entity.Property(e => e.OldValue)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("old_value");

                entity.Property(e => e.PageName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("page_name");

                entity.Property(e => e.ReportId).HasColumnName("report_id");

                entity.Property(e => e.Timestamp)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("timestamp");

                entity.Property(e => e.UserActionTypeId).HasColumnName("user_action_type_id");

                entity.Property(e => e.UserBrowserDetails)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("user_browser_details");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.UserActions)
                    .HasForeignKey(d => d.ReportId)
                    .HasConstraintName("FK_User_actions_Reports");

                entity.HasOne(d => d.UserActionType)
                    .WithMany(p => p.UserActions)
                    .HasForeignKey(d => d.UserActionTypeId)
                    .HasConstraintName("FK_User_actions_User_action_types");
            });

            modelBuilder.Entity<UserActionType>(entity =>
            {
                entity.ToTable("User_action_types");

                entity.Property(e => e.UserActionTypeId).HasColumnName("user_action_type_id");

                entity.Property(e => e.ActionType)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("action_type");

                entity.Property(e => e.ActionTypeDesc)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("action_type_desc");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.Property(e => e.UserGroupId).HasColumnName("user_group_id");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("created_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("created_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DeptId).HasColumnName("dept_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("modified_by")
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_date")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.UserGroupName)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("user_group_name");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.UserGroups)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserGroups_Departments");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
