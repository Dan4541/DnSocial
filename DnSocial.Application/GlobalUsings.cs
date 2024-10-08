﻿global using DnSocial.Application.Models;
global using MediatR;
global using AutoMapper;
global using DnSocial.Application.Enums;
global using DnSocial.Application.Identity.Commands;
global using DnSocial.Application.Options;
global using DnSocial.Dal;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Text;
global using Dn.Domain.Aggregates.UserProfileAggregate;
global using Dn.Domain.Exceptions;
global using DnSocial.Application.UserProfiles.Commands;
global using DnSocial.Application.Posts.Commands;
global using Dn.Domain.Aggregates.PostAggregate;
global using DnSocial.Application.Posts.Queries;
global using DnSocial.Application.UserProfiles.Queries;
