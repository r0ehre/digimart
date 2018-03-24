﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SearchFilter : IDigiFilter
{
    private string[] _tags { get; set; }

    private static readonly Color _FOUND_COLOR = new Color(50, 209, 84, 255);
    private static readonly Color _NOTFOUND_COLOR = new Color(209, 71, 50, 25);

    private static readonly IList<Func<Product, string>> _SELECTORS = new List<Func<Product,string>>()
    {
        p => p.CompanyName,
        p => p.ProductName,
        p => p.ProductSubType
    };

    public SearchFilter(string value)
    {
        _tags = value.Split(' ');
    }


    public Color CalculateOverlayColor(Product product)
    {
        if (_SELECTORS.Any(selector => _tags.Any(tag => selector(product).ToLowerInvariant() == tag.ToLowerInvariant())))
        {
            return _FOUND_COLOR;
        }
        
        return _NOTFOUND_COLOR;
    }
}