namespace Http.Application.DataStore;
public class DataStoreContext
{
    public CodeFolderDataStore CodeFolder { get; }
    public CodeSnippetDataStore CodeSnippet { get; }
    public ConfigOptionDataStore ConfigOption { get; }
    public DocFolderDataStore DocFolder { get; }
    public DocumentDataStore Document { get; }
    public EnvironmentDataStore Environment { get; }
    public PermissionDataStore Permission { get; }
    public ResourceAttributeDataStore ResourceAttribute { get; }
    public ResourceAttributeDefineDataStore ResourceAttributeDefine { get; }
    public ResourceDataStore Resource { get; }
    public ResourceGroupDataStore ResourceGroup { get; }
    public ResourceTagsDataStore ResourceTags { get; }
    public ResourceTypeDefinitionDataStore ResourceTypeDefinition { get; }
    public RoleDataStore Role { get; }
    public RolePermissionDataStore RolePermission { get; }
    public UserDataStore User { get; }

    public DataStoreContext(
        CodeFolderDataStore codeFolder,
        CodeSnippetDataStore codeSnippet,
        ConfigOptionDataStore configOption,
        DocFolderDataStore docFolder,
        DocumentDataStore document,
        EnvironmentDataStore environment,
        PermissionDataStore permission,
        ResourceAttributeDataStore resourceAttribute,
        ResourceAttributeDefineDataStore resourceAttributeDefine,
        ResourceDataStore resource,
        ResourceGroupDataStore resourceGroup,
        ResourceTagsDataStore resourceTags,
        ResourceTypeDefinitionDataStore resourceTypeDefinition,
        RoleDataStore role,
        RolePermissionDataStore rolePermission,
        UserDataStore user)
    {
        CodeFolder = codeFolder;
        CodeSnippet = codeSnippet;
        ConfigOption = configOption;
        DocFolder = docFolder;
        Document = document;
        Environment = environment;
        Permission = permission;
        ResourceAttribute = resourceAttribute;
        ResourceAttributeDefine = resourceAttributeDefine;
        Resource = resource;
        ResourceGroup = resourceGroup;
        ResourceTags = resourceTags;
        ResourceTypeDefinition = resourceTypeDefinition;
        Role = role;
        RolePermission = rolePermission;
        User = user;
    }
}
