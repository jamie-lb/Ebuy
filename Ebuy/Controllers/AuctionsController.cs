﻿using System;
using System.Linq;
using System.Web.Mvc;
using Ebuy.Models;

namespace Ebuy.Controllers
{
    public class AuctionsController : Controller
    {
        //
        // GET: /Auctions/

        public ActionResult Index()
        {
            var db = new EbuyDataContext();
            var auctions = db.Auctions.ToList();
            return View(auctions);
        }

        //
        // GET: /Auctions/Details/5

        public ActionResult Details(long id = 0)
        {
            var auction = new Auction
                {
                    Id = id,
                    Title = "Brand new Widget 2.0",
                    Description = "This is a brand new version 2.0 Widget!",
                    StartPrice = 1.00M,
                    CurrentPrice = 13.40M,
                    StartTime = DateTime.Parse("6-15-2012 12:34 PM"),
                    EndTime = DateTime.Parse("6-23-2012 12:34 PM")
                };
            return View(auction);
        }

        //
        // GET: /Auctions/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Auctions/Create

        [HttpPost]
        public ActionResult Create(Auction auction)
        {
            if (ModelState.IsValid)
            {
                var db = new EbuyDataContext();
                auction.StartTime = DateTime.Now;
                db.Auctions.Add(auction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auction);
        }

        //
        // GET: /Auctions/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Auctions/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Auctions/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Auctions/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
