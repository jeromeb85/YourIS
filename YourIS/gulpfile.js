﻿/*
This file is the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. https://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var sass = require("gulp-sass");

//where to find sass code
paths.sassSource = paths.webroot + "css/**/*.scss";
//where to output compiled CSS code
paths.cssOutput = paths.webroot + "css";

gulp.task('default', function () {
    // place code for your default task here
});

gulp.task('sass', function () {
    gulp.src(paths.sassSource)
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest(paths.cssOutput));
});