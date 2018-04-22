var gulp = require('gulp');
var exec = require('child_process').exec;
var install = require("gulp-install");
var spawn = require('child_process').spawn;
var clean = require('gulp-clean');
var destPath = './wwwroot/';

// Delete the dist directory
gulp.task('clean', function () {
    gulp.src(destPath).pipe(clean());
    return 0;
});

gulp.task('npmInstall', function () {
    gulp.src(['./package.json'])
      .pipe(install());
});

gulp.task('bowerInstall', function () {
    gulp.src(['./bower.json'])
      .pipe(install());
});

gulp.task('ngBuild', function (cb) {
    exec('ng build --delete-output-path=false', {maxBuffer: 1024 * 500}, function (err, stdout, stderr) {
      console.log(stdout);
      console.log(stderr);
      cb(err);
    });
})

gulp.task('ngBuildProd', function (cb) {
    var ls = spawn('ng build --prod', { shell: true });
    ls.stdout.on('data', (data) => {
        console.log(`stdout: ${data}`);
    });
    ls.stderr.on('data', (data) => {
        console.log(`stderr: ${data}`);
    });
    ls.on('close', (code) => {
        console.log(`child process exited with code ${code}`);
    });
})

gulp.task('dotnetRestore', function (cb) {
    exec('dotnet restore', function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        cb(err);
    });
})

gulp.task('dotnetBuild', ['dotnetRestore'], function (cb) {
    exec('dotnet build', function (err, stdout, stderr) {
        console.log(stdout);
        console.log(stderr);
        cb(err);
    });
})

gulp.task('dotnetRun', ['dotnetRestore', 'dotnetBuild'], function (cb) {
    var ls = spawn('dotnet run', { shell: true });
    ls.stdout.on('data', (data) => {
        console.log(`stdout: ${data}`);
    });

    ls.stderr.on('data', (data) => {
        console.log(`stderr: ${data}`);
    });

    ls.on('close', (code) => {
        console.log(`child process exited with code ${code}`);
    });

})

gulp.task('dotnetRunNWatch', ['dotnetRestore', 'dotnetBuild'], function (cb) {
    var ls = spawn('dotnet watch run', { shell: true });
    ls.stdout.on('data', (data) => {
        console.log(`stdout: ${data}`);
    });

    ls.stderr.on('data', (data) => {
        console.log(`stderr: ${data}`);
    });

    ls.on('close', (code) => {
        console.log(`child process exited with code ${code}`);
    });

})

gulp.task('watch', ['ngBuild'], function () {
    gulp.watch('./src/**/*', ['ngBuild'])
    return 0;
});

gulp.task('default', ['npmInstall', 'bowerInstall', 'watch']);