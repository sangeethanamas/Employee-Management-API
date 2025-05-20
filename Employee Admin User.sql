select*from AspNetUsers;
select*from AspNetRoles;
select*from AspNetUserRoles;
select*from AspNetRoleClaims;
select*from AspNetUserLogins;
select*from AspNetUserTokens;

select Email,Name as Rolename,UserId,RoleId from AspNetUsers
join AspNetUserRoles on AspNetUsers.Id=AspNetUserRoles.UserId 
join AspNetRoles on AspNetRoles.Id=AspNetUserRoles.RoleId;

