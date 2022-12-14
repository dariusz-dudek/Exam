global using AutoMapper;
global using Exam.API.DTO.AuthorDTO;
global using Exam.API.DTO.MaterialDTO;
global using Exam.API.DTO.MaterialsDTO;
global using Exam.API.DTO.ReviewDTO;
global using Exam.API.Middleware;
global using Exam.API.Services;
global using Exam.API.Services.Interfaces;
global using Exam.Data.Context;
global using Exam.Data.DAL.Interfaces;
global using Exam.Data.DAL.Repositories;
global using Exam.Data.Entries;
global using Exam.Data.Exceptions;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using Swashbuckle.AspNetCore.Annotations;
global using System.ComponentModel.DataAnnotations;
global using System.IdentityModel.Tokens.Jwt;
global using System.Net.Mime;
global using System.Reflection;
global using System.Security.Claims;
global using System.Text;