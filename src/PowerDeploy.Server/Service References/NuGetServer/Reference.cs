//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Original file name:
// Generation date: 23.05.2014 18:39:26
namespace PowerDeploy.Server.NuGetServer
{
    
    /// <summary>
    /// There are no comments for PackageContext in the schema.
    /// </summary>
    public partial class PackageContext : global::System.Data.Services.Client.DataServiceContext
    {
        /// <summary>
        /// Initialize a new PackageContext object.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public PackageContext(global::System.Uri serviceRoot) : 
                base(serviceRoot)
        {
            this.ResolveName = new global::System.Func<global::System.Type, string>(this.ResolveNameFromType);
            this.ResolveType = new global::System.Func<string, global::System.Type>(this.ResolveTypeFromName);
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected global::System.Type ResolveTypeFromName(string typeName)
        {
            global::System.Type resolvedType = this.DefaultResolveType(typeName, "NuGet.Server.DataServices", "PowerDeploy.Server.NuGetServer");
            if ((resolvedType != null))
            {
                return resolvedType;
            }
            return null;
        }
        /// <summary>
        /// Since the namespace configured for this service reference
        /// in Visual Studio is different from the one indicated in the
        /// server schema, use type-mappers to map between the two.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected string ResolveNameFromType(global::System.Type clientType)
        {
            if (clientType.Namespace.Equals("PowerDeploy.Server.NuGetServer", global::System.StringComparison.Ordinal))
            {
                return string.Concat("NuGet.Server.DataServices.", clientType.Name);
            }
            return null;
        }
        /// <summary>
        /// There are no comments for Packages in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<Package> Packages
        {
            get
            {
                if ((this._Packages == null))
                {
                    this._Packages = base.CreateQuery<Package>("Packages");
                }
                return this._Packages;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<Package> _Packages;
        /// <summary>
        /// There are no comments for Packages in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToPackages(Package package)
        {
            base.AddObject("Packages", package);
        }
    }
    /// <summary>
    /// There are no comments for NuGet.Server.DataServices.Package in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Id
    /// Version
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("Packages")]
    [global::System.Data.Services.Common.EntityPropertyMappingAttribute("Id", global::System.Data.Services.Common.SyndicationItemProperty.Title, global::System.Data.Services.Common.SyndicationTextContentKind.Plaintext, false)]
    [global::System.Data.Services.Common.EntityPropertyMappingAttribute("Authors", global::System.Data.Services.Common.SyndicationItemProperty.AuthorName, global::System.Data.Services.Common.SyndicationTextContentKind.Plaintext, false)]
    [global::System.Data.Services.Common.EntityPropertyMappingAttribute("Summary", global::System.Data.Services.Common.SyndicationItemProperty.Summary, global::System.Data.Services.Common.SyndicationTextContentKind.Plaintext, false)]
    [global::System.Data.Services.Common.EntityPropertyMappingAttribute("LastUpdated", global::System.Data.Services.Common.SyndicationItemProperty.Updated, global::System.Data.Services.Common.SyndicationTextContentKind.Plaintext, false)]
    [global::System.Data.Services.Common.HasStreamAttribute()]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("Id", "Version")]
    public partial class Package : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new Package object.
        /// </summary>
        /// <param name="ID">Initial value of Id.</param>
        /// <param name="version">Initial value of Version.</param>
        /// <param name="isPrerelease">Initial value of IsPrerelease.</param>
        /// <param name="downloadCount">Initial value of DownloadCount.</param>
        /// <param name="requireLicenseAcceptance">Initial value of RequireLicenseAcceptance.</param>
        /// <param name="developmentDependency">Initial value of DevelopmentDependency.</param>
        /// <param name="published">Initial value of Published.</param>
        /// <param name="lastUpdated">Initial value of LastUpdated.</param>
        /// <param name="packageSize">Initial value of PackageSize.</param>
        /// <param name="isAbsoluteLatestVersion">Initial value of IsAbsoluteLatestVersion.</param>
        /// <param name="isLatestVersion">Initial value of IsLatestVersion.</param>
        /// <param name="listed">Initial value of Listed.</param>
        /// <param name="versionDownloadCount">Initial value of VersionDownloadCount.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static Package CreatePackage(string ID, string version, bool isPrerelease, int downloadCount, bool requireLicenseAcceptance, bool developmentDependency, global::System.DateTime published, global::System.DateTime lastUpdated, long packageSize, bool isAbsoluteLatestVersion, bool isLatestVersion, bool listed, int versionDownloadCount)
        {
            Package package = new Package();
            package.Id = ID;
            package.Version = version;
            package.IsPrerelease = isPrerelease;
            package.DownloadCount = downloadCount;
            package.RequireLicenseAcceptance = requireLicenseAcceptance;
            package.DevelopmentDependency = developmentDependency;
            package.Published = published;
            package.LastUpdated = lastUpdated;
            package.PackageSize = packageSize;
            package.IsAbsoluteLatestVersion = isAbsoluteLatestVersion;
            package.IsLatestVersion = isLatestVersion;
            package.Listed = listed;
            package.VersionDownloadCount = versionDownloadCount;
            return package;
        }
        /// <summary>
        /// There are no comments for Property Id in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this.OnIdChanging(value);
                this._Id = value;
                this.OnIdChanged();
                this.OnPropertyChanged("Id");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Id;
        partial void OnIdChanging(string value);
        partial void OnIdChanged();
        /// <summary>
        /// There are no comments for Property Version in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Version
        {
            get
            {
                return this._Version;
            }
            set
            {
                this.OnVersionChanging(value);
                this._Version = value;
                this.OnVersionChanged();
                this.OnPropertyChanged("Version");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Version;
        partial void OnVersionChanging(string value);
        partial void OnVersionChanged();
        /// <summary>
        /// There are no comments for Property IsPrerelease in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public bool IsPrerelease
        {
            get
            {
                return this._IsPrerelease;
            }
            set
            {
                this.OnIsPrereleaseChanging(value);
                this._IsPrerelease = value;
                this.OnIsPrereleaseChanged();
                this.OnPropertyChanged("IsPrerelease");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private bool _IsPrerelease;
        partial void OnIsPrereleaseChanging(bool value);
        partial void OnIsPrereleaseChanged();
        /// <summary>
        /// There are no comments for Property Title in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                this.OnTitleChanging(value);
                this._Title = value;
                this.OnTitleChanged();
                this.OnPropertyChanged("Title");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Title;
        partial void OnTitleChanging(string value);
        partial void OnTitleChanged();
        /// <summary>
        /// There are no comments for Property Authors in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Authors
        {
            get
            {
                return this._Authors;
            }
            set
            {
                this.OnAuthorsChanging(value);
                this._Authors = value;
                this.OnAuthorsChanged();
                this.OnPropertyChanged("Authors");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Authors;
        partial void OnAuthorsChanging(string value);
        partial void OnAuthorsChanged();
        /// <summary>
        /// There are no comments for Property Owners in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Owners
        {
            get
            {
                return this._Owners;
            }
            set
            {
                this.OnOwnersChanging(value);
                this._Owners = value;
                this.OnOwnersChanged();
                this.OnPropertyChanged("Owners");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Owners;
        partial void OnOwnersChanging(string value);
        partial void OnOwnersChanged();
        /// <summary>
        /// There are no comments for Property IconUrl in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string IconUrl
        {
            get
            {
                return this._IconUrl;
            }
            set
            {
                this.OnIconUrlChanging(value);
                this._IconUrl = value;
                this.OnIconUrlChanged();
                this.OnPropertyChanged("IconUrl");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _IconUrl;
        partial void OnIconUrlChanging(string value);
        partial void OnIconUrlChanged();
        /// <summary>
        /// There are no comments for Property LicenseUrl in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string LicenseUrl
        {
            get
            {
                return this._LicenseUrl;
            }
            set
            {
                this.OnLicenseUrlChanging(value);
                this._LicenseUrl = value;
                this.OnLicenseUrlChanged();
                this.OnPropertyChanged("LicenseUrl");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _LicenseUrl;
        partial void OnLicenseUrlChanging(string value);
        partial void OnLicenseUrlChanged();
        /// <summary>
        /// There are no comments for Property ProjectUrl in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ProjectUrl
        {
            get
            {
                return this._ProjectUrl;
            }
            set
            {
                this.OnProjectUrlChanging(value);
                this._ProjectUrl = value;
                this.OnProjectUrlChanged();
                this.OnPropertyChanged("ProjectUrl");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ProjectUrl;
        partial void OnProjectUrlChanging(string value);
        partial void OnProjectUrlChanged();
        /// <summary>
        /// There are no comments for Property DownloadCount in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int DownloadCount
        {
            get
            {
                return this._DownloadCount;
            }
            set
            {
                this.OnDownloadCountChanging(value);
                this._DownloadCount = value;
                this.OnDownloadCountChanged();
                this.OnPropertyChanged("DownloadCount");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _DownloadCount;
        partial void OnDownloadCountChanging(int value);
        partial void OnDownloadCountChanged();
        /// <summary>
        /// There are no comments for Property RequireLicenseAcceptance in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public bool RequireLicenseAcceptance
        {
            get
            {
                return this._RequireLicenseAcceptance;
            }
            set
            {
                this.OnRequireLicenseAcceptanceChanging(value);
                this._RequireLicenseAcceptance = value;
                this.OnRequireLicenseAcceptanceChanged();
                this.OnPropertyChanged("RequireLicenseAcceptance");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private bool _RequireLicenseAcceptance;
        partial void OnRequireLicenseAcceptanceChanging(bool value);
        partial void OnRequireLicenseAcceptanceChanged();
        /// <summary>
        /// There are no comments for Property DevelopmentDependency in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public bool DevelopmentDependency
        {
            get
            {
                return this._DevelopmentDependency;
            }
            set
            {
                this.OnDevelopmentDependencyChanging(value);
                this._DevelopmentDependency = value;
                this.OnDevelopmentDependencyChanged();
                this.OnPropertyChanged("DevelopmentDependency");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private bool _DevelopmentDependency;
        partial void OnDevelopmentDependencyChanging(bool value);
        partial void OnDevelopmentDependencyChanged();
        /// <summary>
        /// There are no comments for Property Description in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                this.OnDescriptionChanging(value);
                this._Description = value;
                this.OnDescriptionChanged();
                this.OnPropertyChanged("Description");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Description;
        partial void OnDescriptionChanging(string value);
        partial void OnDescriptionChanged();
        /// <summary>
        /// There are no comments for Property Summary in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Summary
        {
            get
            {
                return this._Summary;
            }
            set
            {
                this.OnSummaryChanging(value);
                this._Summary = value;
                this.OnSummaryChanged();
                this.OnPropertyChanged("Summary");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Summary;
        partial void OnSummaryChanging(string value);
        partial void OnSummaryChanged();
        /// <summary>
        /// There are no comments for Property ReleaseNotes in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string ReleaseNotes
        {
            get
            {
                return this._ReleaseNotes;
            }
            set
            {
                this.OnReleaseNotesChanging(value);
                this._ReleaseNotes = value;
                this.OnReleaseNotesChanged();
                this.OnPropertyChanged("ReleaseNotes");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _ReleaseNotes;
        partial void OnReleaseNotesChanging(string value);
        partial void OnReleaseNotesChanged();
        /// <summary>
        /// There are no comments for Property Published in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.DateTime Published
        {
            get
            {
                return this._Published;
            }
            set
            {
                this.OnPublishedChanging(value);
                this._Published = value;
                this.OnPublishedChanged();
                this.OnPropertyChanged("Published");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.DateTime _Published;
        partial void OnPublishedChanging(global::System.DateTime value);
        partial void OnPublishedChanged();
        /// <summary>
        /// There are no comments for Property LastUpdated in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.DateTime LastUpdated
        {
            get
            {
                return this._LastUpdated;
            }
            set
            {
                this.OnLastUpdatedChanging(value);
                this._LastUpdated = value;
                this.OnLastUpdatedChanged();
                this.OnPropertyChanged("LastUpdated");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.DateTime _LastUpdated;
        partial void OnLastUpdatedChanging(global::System.DateTime value);
        partial void OnLastUpdatedChanged();
        /// <summary>
        /// There are no comments for Property Dependencies in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Dependencies
        {
            get
            {
                return this._Dependencies;
            }
            set
            {
                this.OnDependenciesChanging(value);
                this._Dependencies = value;
                this.OnDependenciesChanged();
                this.OnPropertyChanged("Dependencies");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Dependencies;
        partial void OnDependenciesChanging(string value);
        partial void OnDependenciesChanged();
        /// <summary>
        /// There are no comments for Property PackageHash in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string PackageHash
        {
            get
            {
                return this._PackageHash;
            }
            set
            {
                this.OnPackageHashChanging(value);
                this._PackageHash = value;
                this.OnPackageHashChanged();
                this.OnPropertyChanged("PackageHash");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _PackageHash;
        partial void OnPackageHashChanging(string value);
        partial void OnPackageHashChanged();
        /// <summary>
        /// There are no comments for Property PackageHashAlgorithm in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string PackageHashAlgorithm
        {
            get
            {
                return this._PackageHashAlgorithm;
            }
            set
            {
                this.OnPackageHashAlgorithmChanging(value);
                this._PackageHashAlgorithm = value;
                this.OnPackageHashAlgorithmChanged();
                this.OnPropertyChanged("PackageHashAlgorithm");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _PackageHashAlgorithm;
        partial void OnPackageHashAlgorithmChanging(string value);
        partial void OnPackageHashAlgorithmChanged();
        /// <summary>
        /// There are no comments for Property PackageSize in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public long PackageSize
        {
            get
            {
                return this._PackageSize;
            }
            set
            {
                this.OnPackageSizeChanging(value);
                this._PackageSize = value;
                this.OnPackageSizeChanged();
                this.OnPropertyChanged("PackageSize");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private long _PackageSize;
        partial void OnPackageSizeChanging(long value);
        partial void OnPackageSizeChanged();
        /// <summary>
        /// There are no comments for Property Copyright in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Copyright
        {
            get
            {
                return this._Copyright;
            }
            set
            {
                this.OnCopyrightChanging(value);
                this._Copyright = value;
                this.OnCopyrightChanged();
                this.OnPropertyChanged("Copyright");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Copyright;
        partial void OnCopyrightChanging(string value);
        partial void OnCopyrightChanged();
        /// <summary>
        /// There are no comments for Property Tags in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Tags
        {
            get
            {
                return this._Tags;
            }
            set
            {
                this.OnTagsChanging(value);
                this._Tags = value;
                this.OnTagsChanged();
                this.OnPropertyChanged("Tags");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Tags;
        partial void OnTagsChanging(string value);
        partial void OnTagsChanged();
        /// <summary>
        /// There are no comments for Property IsAbsoluteLatestVersion in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public bool IsAbsoluteLatestVersion
        {
            get
            {
                return this._IsAbsoluteLatestVersion;
            }
            set
            {
                this.OnIsAbsoluteLatestVersionChanging(value);
                this._IsAbsoluteLatestVersion = value;
                this.OnIsAbsoluteLatestVersionChanged();
                this.OnPropertyChanged("IsAbsoluteLatestVersion");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private bool _IsAbsoluteLatestVersion;
        partial void OnIsAbsoluteLatestVersionChanging(bool value);
        partial void OnIsAbsoluteLatestVersionChanged();
        /// <summary>
        /// There are no comments for Property IsLatestVersion in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public bool IsLatestVersion
        {
            get
            {
                return this._IsLatestVersion;
            }
            set
            {
                this.OnIsLatestVersionChanging(value);
                this._IsLatestVersion = value;
                this.OnIsLatestVersionChanged();
                this.OnPropertyChanged("IsLatestVersion");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private bool _IsLatestVersion;
        partial void OnIsLatestVersionChanging(bool value);
        partial void OnIsLatestVersionChanged();
        /// <summary>
        /// There are no comments for Property Listed in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public bool Listed
        {
            get
            {
                return this._Listed;
            }
            set
            {
                this.OnListedChanging(value);
                this._Listed = value;
                this.OnListedChanged();
                this.OnPropertyChanged("Listed");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private bool _Listed;
        partial void OnListedChanging(bool value);
        partial void OnListedChanged();
        /// <summary>
        /// There are no comments for Property VersionDownloadCount in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public int VersionDownloadCount
        {
            get
            {
                return this._VersionDownloadCount;
            }
            set
            {
                this.OnVersionDownloadCountChanging(value);
                this._VersionDownloadCount = value;
                this.OnVersionDownloadCountChanged();
                this.OnPropertyChanged("VersionDownloadCount");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private int _VersionDownloadCount;
        partial void OnVersionDownloadCountChanging(int value);
        partial void OnVersionDownloadCountChanged();
        /// <summary>
        /// There are no comments for Property MinClientVersion in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string MinClientVersion
        {
            get
            {
                return this._MinClientVersion;
            }
            set
            {
                this.OnMinClientVersionChanging(value);
                this._MinClientVersion = value;
                this.OnMinClientVersionChanged();
                this.OnPropertyChanged("MinClientVersion");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _MinClientVersion;
        partial void OnMinClientVersionChanging(string value);
        partial void OnMinClientVersionChanged();
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
}
