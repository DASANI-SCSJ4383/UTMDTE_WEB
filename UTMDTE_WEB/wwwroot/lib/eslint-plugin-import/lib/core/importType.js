'use strict';Object.defineProperty(exports, "__esModule", { value: true });var _slicedToArray = function () {function sliceIterator(arr, i) {var _arr = [];var _n = true;var _d = false;var _e = undefined;try {for (var _i = arr[Symbol.iterator](), _s; !(_n = (_s = _i.next()).done); _n = true) {_arr.push(_s.value);if (i && _arr.length === i) break;}} catch (err) {_d = true;_e = err;} finally {try {if (!_n && _i["return"]) _i["return"]();} finally {if (_d) throw _e;}}return _arr;}return function (arr, i) {if (Array.isArray(arr)) {return arr;} else if (Symbol.iterator in Object(arr)) {return sliceIterator(arr, i);} else {throw new TypeError("Invalid attempt to destructure non-iterable instance");}};}();exports.



















isAbsolute = isAbsolute;exports.




isBuiltIn = isBuiltIn;exports.






isExternalModule = isExternalModule;exports.






isExternalModuleMain = isExternalModuleMain;exports.

















isScoped = isScoped;exports.




isScopedMain = isScopedMain;exports['default'] =






























































resolveImportType;var _path = require('path');var _isCoreModule = require('is-core-module');var _isCoreModule2 = _interopRequireDefault(_isCoreModule);var _resolve = require('eslint-module-utils/resolve');var _resolve2 = _interopRequireDefault(_resolve);var _packagePath = require('./packagePath');function _interopRequireDefault(obj) {return obj && obj.__esModule ? obj : { 'default': obj };}function baseModule(name) {if (isScoped(name)) {var _name$split = name.split('/'),_name$split2 = _slicedToArray(_name$split, 2),scope = _name$split2[0],_pkg = _name$split2[1];return String(scope) + '/' + String(_pkg);}var _name$split3 = name.split('/'),_name$split4 = _slicedToArray(_name$split3, 1),pkg = _name$split4[0];return pkg;}function isInternalRegexMatch(name, settings) {var internalScope = settings && settings['import/internal-regex'];return internalScope && new RegExp(internalScope).test(name);}function isAbsolute(name) {return typeof name === 'string' && (0, _path.isAbsolute)(name);} // path is defined only when a resolver resolves to a non-standard path
function isBuiltIn(name, settings, path) {if (path || !name) return false;var base = baseModule(name);var extras = settings && settings['import/core-modules'] || [];return (0, _isCoreModule2['default'])(base) || extras.indexOf(base) > -1;}function isExternalModule(name, path, context) {if (arguments.length < 3) {throw new TypeError('isExternalModule: name, path, and context are all required');}return (isModule(name) || isScoped(name)) && typeTest(name, context, path) === 'external';}function isExternalModuleMain(name, path, context) {if (arguments.length < 3) {throw new TypeError('isExternalModule: name, path, and context are all required');}return isModuleMain(name) && typeTest(name, context, path) === 'external';}var moduleRegExp = /^\w/;function isModule(name) {return name && moduleRegExp.test(name);}var moduleMainRegExp = /^[\w]((?!\/).)*$/;function isModuleMain(name) {return name && moduleMainRegExp.test(name);}var scopedRegExp = /^@[^/]+\/?[^/]+/;function isScoped(name) {return name && scopedRegExp.test(name);}var scopedMainRegExp = /^@[^/]+\/?[^/]+$/;function isScopedMain(name) {return name && scopedMainRegExp.test(name);}function isRelativeToParent(name) {return (/^\.\.$|^\.\.[\\/]/.test(name));}var indexFiles = ['.', './', './index', './index.js'];function isIndex(name) {return indexFiles.indexOf(name) !== -1;}function isRelativeToSibling(name) {return (/^\.[\\/]/.test(name));}function isExternalPath(path, context) {if (!path) {return false;}var settings = context.settings;var packagePath = (0, _packagePath.getContextPackagePath)(context);if ((0, _path.relative)(packagePath, path).startsWith('..')) {return true;}var folders = settings && settings['import/external-module-folders'] || ['node_modules'];return folders.some(function (folder) {var folderPath = (0, _path.resolve)(packagePath, folder);var relativePath = (0, _path.relative)(folderPath, path);return !relativePath.startsWith('..');});}function isInternalPath(path, context) {if (!path) {return false;}var packagePath = (0, _packagePath.getContextPackagePath)(context);return !(0, _path.relative)(packagePath, path).startsWith('../');}function isExternalLookingName(name) {return isModule(name) || isScoped(name);}function typeTest(name, context, path) {var settings = context.settings;if (isInternalRegexMatch(name, settings)) {return 'internal';}if (isAbsolute(name, settings, path)) {return 'absolute';}if (isBuiltIn(name, settings, path)) {return 'builtin';}if (isRelativeToParent(name, settings, path)) {return 'parent';}if (isIndex(name, settings, path)) {return 'index';}if (isRelativeToSibling(name, settings, path)) {return 'sibling';}if (isExternalPath(path, context)) {return 'external';}if (isInternalPath(path, context)) {return 'internal';}if (isExternalLookingName(name)) {return 'external';}return 'unknown';}function resolveImportType(name, context) {return typeTest(name, context, (0, _resolve2['default'])(name, context));
}
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIi4uLy4uL3NyYy9jb3JlL2ltcG9ydFR5cGUuanMiXSwibmFtZXMiOlsiaXNBYnNvbHV0ZSIsImlzQnVpbHRJbiIsImlzRXh0ZXJuYWxNb2R1bGUiLCJpc0V4dGVybmFsTW9kdWxlTWFpbiIsImlzU2NvcGVkIiwiaXNTY29wZWRNYWluIiwicmVzb2x2ZUltcG9ydFR5cGUiLCJiYXNlTW9kdWxlIiwibmFtZSIsInNwbGl0Iiwic2NvcGUiLCJwa2ciLCJpc0ludGVybmFsUmVnZXhNYXRjaCIsInNldHRpbmdzIiwiaW50ZXJuYWxTY29wZSIsIlJlZ0V4cCIsInRlc3QiLCJwYXRoIiwiYmFzZSIsImV4dHJhcyIsImluZGV4T2YiLCJjb250ZXh0IiwiYXJndW1lbnRzIiwibGVuZ3RoIiwiVHlwZUVycm9yIiwiaXNNb2R1bGUiLCJ0eXBlVGVzdCIsImlzTW9kdWxlTWFpbiIsIm1vZHVsZVJlZ0V4cCIsIm1vZHVsZU1haW5SZWdFeHAiLCJzY29wZWRSZWdFeHAiLCJzY29wZWRNYWluUmVnRXhwIiwiaXNSZWxhdGl2ZVRvUGFyZW50IiwiaW5kZXhGaWxlcyIsImlzSW5kZXgiLCJpc1JlbGF0aXZlVG9TaWJsaW5nIiwiaXNFeHRlcm5hbFBhdGgiLCJwYWNrYWdlUGF0aCIsInN0YXJ0c1dpdGgiLCJmb2xkZXJzIiwic29tZSIsImZvbGRlciIsImZvbGRlclBhdGgiLCJyZWxhdGl2ZVBhdGgiLCJpc0ludGVybmFsUGF0aCIsImlzRXh0ZXJuYWxMb29raW5nTmFtZSJdLCJtYXBwaW5ncyI6Ijs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7QUFvQmdCQSxVLEdBQUFBLFU7Ozs7O0FBS0FDLFMsR0FBQUEsUzs7Ozs7OztBQU9BQyxnQixHQUFBQSxnQjs7Ozs7OztBQU9BQyxvQixHQUFBQSxvQjs7Ozs7Ozs7Ozs7Ozs7Ozs7O0FBa0JBQyxRLEdBQUFBLFE7Ozs7O0FBS0FDLFksR0FBQUEsWTs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7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VUFBUCxDQUFvQixDQUN6RCxJQUFJdUIsZUFBZTNCLElBQWYsRUFBcUJJLE9BQXJCLENBQUosRUFBbUMsQ0FBRSxPQUFPLFVBQVAsQ0FBb0IsQ0FDekQsSUFBSXdCLHNCQUFzQnJDLElBQXRCLENBQUosRUFBaUMsQ0FBRSxPQUFPLFVBQVAsQ0FBb0IsQ0FDdkQsT0FBTyxTQUFQLENBQ0QsQ0FFYyxTQUFTRixpQkFBVCxDQUEyQkUsSUFBM0IsRUFBaUNhLE9BQWpDLEVBQTBDLENBQ3ZELE9BQU9LLFNBQVNsQixJQUFULEVBQWVhLE9BQWYsRUFBd0IsMEJBQVFiLElBQVIsRUFBY2EsT0FBZCxDQUF4QixDQUFQO0FBQ0QiLCJmaWxlIjoiaW1wb3J0VHlwZS5qcyIsInNvdXJjZXNDb250ZW50IjpbImltcG9ydCB7IGlzQWJzb2x1dGUgYXMgbm9kZUlzQWJzb2x1dGUsIHJlbGF0aXZlLCByZXNvbHZlIGFzIG5vZGVSZXNvbHZlIH0gZnJvbSAncGF0aCc7XG5pbXBvcnQgaXNDb3JlTW9kdWxlIGZyb20gJ2lzLWNvcmUtbW9kdWxlJztcblxuaW1wb3J0IHJlc29sdmUgZnJvbSAnZXNsaW50LW1vZHVsZS11dGlscy9yZXNvbHZlJztcbmltcG9ydCB7IGdldENvbnRleHRQYWNrYWdlUGF0aCB9IGZyb20gJy4vcGFja2FnZVBhdGgnO1xuXG5mdW5jdGlvbiBiYXNlTW9kdWxlKG5hbWUpIHtcbiAgaWYgKGlzU2NvcGVkKG5hbWUpKSB7XG4gICAgY29uc3QgW3Njb3BlLCBwa2ddID0gbmFtZS5zcGxpdCgnLycpO1xuICAgIHJldHVybiBgJHtzY29wZX0vJHtwa2d9YDtcbiAgfVxuICBjb25zdCBbcGtnXSA9IG5hbWUuc3BsaXQoJy8nKTtcbiAgcmV0dXJuIHBrZztcbn1cblxuZnVuY3Rpb24gaXNJbnRlcm5hbFJlZ2V4TWF0Y2gobmFtZSwgc2V0dGluZ3MpIHtcbiAgY29uc3QgaW50ZXJuYWxTY29wZSA9IChzZXR0aW5ncyAmJiBzZXR0aW5nc1snaW1wb3J0L2ludGVybmFsLXJlZ2V4J10pO1xuICByZXR1cm4gaW50ZXJuYWxTY29wZSAmJiBuZXcgUmVnRXhwKGludGVybmFsU2NvcGUpLnRlc3QobmFtZSk7XG59XG5cbmV4cG9ydCBmdW5jdGlvbiBpc0Fic29sdXRlKG5hbWUpIHtcbiAgcmV0dXJuIHR5cGVvZiBuYW1lID09PSAnc3RyaW5nJyAmJiBub2RlSXNBYnNvbHV0ZShuYW1lKTtcbn1cblxuLy8gcGF0aCBpcyBkZWZpbmVkIG9ubHkgd2hlbiBhIHJlc29sdmVyIHJlc29sdmVzIHRvIGEgbm9uLXN0YW5kYXJkIHBhdGhcbmV4cG9ydCBmdW5jdGlvbiBpc0J1aWx0SW4obmFtZSwgc2V0dGluZ3MsIHBhdGgpIHtcbiAgaWYgKHBhdGggfHwgIW5hbWUpIHJldHVybiBmYWxzZTtcbiAgY29uc3QgYmFzZSA9IGJhc2VNb2R1bGUobmFtZSk7XG4gIGNvbnN0IGV4dHJhcyA9IChzZXR0aW5ncyAmJiBzZXR0aW5nc1snaW1wb3J0L2NvcmUtbW9kdWxlcyddKSB8fCBbXTtcbiAgcmV0dXJuIGlzQ29yZU1vZHVsZShiYXNlKSB8fCBleHRyYXMuaW5kZXhPZihiYXNlKSA+IC0xO1xufVxuXG5leHBvcnQgZnVuY3Rpb24gaXNFeHRlcm5hbE1vZHVsZShuYW1lLCBwYXRoLCBjb250ZXh0KSB7XG4gIGlmIChhcmd1bWVudHMubGVuZ3RoIDwgMykgeyAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIFxuICAgIHRocm93IG5ldyBUeXBlRXJyb3IoJ2lzRXh0ZXJuYWxNb2R1bGU6IG5hbWUsIHBhdGgsIGFuZCBjb250ZXh0IGFyZSBhbGwgcmVxdWlyZWQnKTtcbiAgfVxuICByZXR1cm4gKGlzTW9kdWxlKG5hbWUpIHx8IGlzU2NvcGVkKG5hbWUpKSAmJiB0eXBlVGVzdChuYW1lLCBjb250ZXh0LCBwYXRoKSA9PT0gJ2V4dGVybmFsJztcbn1cblxuZXhwb3J0IGZ1bmN0aW9uIGlzRXh0ZXJuYWxNb2R1bGVNYWluKG5hbWUsIHBhdGgsIGNvbnRleHQpIHtcbiAgaWYgKGFyZ3VtZW50cy5sZW5ndGggPCAzKSB7ICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgXG4gICAgdGhyb3cgbmV3IFR5cGVFcnJvcignaXNFeHRlcm5hbE1vZHVsZTogbmFtZSwgcGF0aCwgYW5kIGNvbnRleHQgYXJlIGFsbCByZXF1aXJlZCcpO1xuICB9XG4gIHJldHVybiBpc01vZHVsZU1haW4obmFtZSkgJiYgdHlwZVRlc3QobmFtZSwgY29udGV4dCwgcGF0aCkgPT09ICdleHRlcm5hbCc7XG59XG5cbmNvbnN0IG1vZHVsZVJlZ0V4cCA9IC9eXFx3LztcbmZ1bmN0aW9uIGlzTW9kdWxlKG5hbWUpIHtcbiAgcmV0dXJuIG5hbWUgJiYgbW9kdWxlUmVnRXhwLnRlc3QobmFtZSk7XG59XG5cbmNvbnN0IG1vZHVsZU1haW5SZWdFeHAgPSAvXltcXHddKCg/IVxcLykuKSokLztcbmZ1bmN0aW9uIGlzTW9kdWxlTWFpbihuYW1lKSB7XG4gIHJldHVybiBuYW1lICYmIG1vZHVsZU1haW5SZWdFeHAudGVzdChuYW1lKTtcbn1cblxuY29uc3Qgc2NvcGVkUmVnRXhwID0gL15AW14vXStcXC8/W14vXSsvO1xuZXhwb3J0IGZ1bmN0aW9uIGlzU2NvcGVkKG5hbWUpIHtcbiAgcmV0dXJuIG5hbWUgJiYgc2NvcGVkUmVnRXhwLnRlc3QobmFtZSk7XG59XG5cbmNvbnN0IHNjb3BlZE1haW5SZWdFeHAgPSAvXkBbXi9dK1xcLz9bXi9dKyQvO1xuZXhwb3J0IGZ1bmN0aW9uIGlzU2NvcGVkTWFpbihuYW1lKSB7XG4gIHJldHVybiBuYW1lICYmIHNjb3BlZE1haW5SZWdFeHAudGVzdChuYW1lKTtcbn1cblxuZnVuY3Rpb24gaXNSZWxhdGl2ZVRvUGFyZW50KG5hbWUpIHtcbiAgcmV0dXJuIC9eXFwuXFwuJHxeXFwuXFwuW1xcXFwvXS8udGVzdChuYW1lKTtcbn1cblxuY29uc3QgaW5kZXhGaWxlcyA9IFsnLicsICcuLycsICcuL2luZGV4JywgJy4vaW5kZXguanMnXTtcbmZ1bmN0aW9uIGlzSW5kZXgobmFtZSkge1xuICByZXR1cm4gaW5kZXhGaWxlcy5pbmRleE9mKG5hbWUpICE9PSAtMTtcbn1cblxuZnVuY3Rpb24gaXNSZWxhdGl2ZVRvU2libGluZyhuYW1lKSB7XG4gIHJldHVybiAvXlxcLltcXFxcL10vLnRlc3QobmFtZSk7XG59XG5cbmZ1bmN0aW9uIGlzRXh0ZXJuYWxQYXRoKHBhdGgsIGNvbnRleHQpIHtcbiAgaWYgKCFwYXRoKSB7XG4gICAgcmV0dXJuIGZhbHNlO1xuICB9XG5cbiAgY29uc3QgeyBzZXR0aW5ncyB9ID0gY29udGV4dDtcbiAgY29uc3QgcGFja2FnZVBhdGggPSBnZXRDb250ZXh0UGFja2FnZVBhdGgoY29udGV4dCk7XG5cbiAgaWYgKHJlbGF0aXZlKHBhY2thZ2VQYXRoLCBwYXRoKS5zdGFydHNXaXRoKCcuLicpKSB7XG4gICAgcmV0dXJuIHRydWU7XG4gIH1cblxuICBjb25zdCBmb2xkZXJzID0gKHNldHRpbmdzICYmIHNldHRpbmdzWydpbXBvcnQvZXh0ZXJuYWwtbW9kdWxlLWZvbGRlcnMnXSkgfHwgWydub2RlX21vZHVsZXMnXTtcbiAgcmV0dXJuIGZvbGRlcnMuc29tZSgoZm9sZGVyKSA9PiB7XG4gICAgY29uc3QgZm9sZGVyUGF0aCA9IG5vZGVSZXNvbHZlKHBhY2thZ2VQYXRoLCBmb2xkZXIpO1xuICAgIGNvbnN0IHJlbGF0aXZlUGF0aCA9IHJlbGF0aXZlKGZvbGRlclBhdGgsIHBhdGgpO1xuICAgIHJldHVybiAhcmVsYXRpdmVQYXRoLnN0YXJ0c1dpdGgoJy4uJyk7XG4gIH0pO1xufVxuXG5mdW5jdGlvbiBpc0ludGVybmFsUGF0aChwYXRoLCBjb250ZXh0KSB7XG4gIGlmICghcGF0aCkge1xuICAgIHJldHVybiBmYWxzZTtcbiAgfVxuICBjb25zdCBwYWNrYWdlUGF0aCA9IGdldENvbnRleHRQYWNrYWdlUGF0aChjb250ZXh0KTtcbiAgcmV0dXJuICFyZWxhdGl2ZShwYWNrYWdlUGF0aCwgcGF0aCkuc3RhcnRzV2l0aCgnLi4vJyk7XG59XG5cbmZ1bmN0aW9uIGlzRXh0ZXJuYWxMb29raW5nTmFtZShuYW1lKSB7XG4gIHJldHVybiBpc01vZHVsZShuYW1lKSB8fCBpc1Njb3BlZChuYW1lKTtcbn1cblxuZnVuY3Rpb24gdHlwZVRlc3QobmFtZSwgY29udGV4dCwgcGF0aCApIHtcbiAgY29uc3QgeyBzZXR0aW5ncyB9ID0gY29udGV4dDtcbiAgaWYgKGlzSW50ZXJuYWxSZWdleE1hdGNoKG5hbWUsIHNldHRpbmdzKSkgeyByZXR1cm4gJ2ludGVybmFsJzsgfVxuICBpZiAoaXNBYnNvbHV0ZShuYW1lLCBzZXR0aW5ncywgcGF0aCkpIHsgcmV0dXJuICdhYnNvbHV0ZSc7IH1cbiAgaWYgKGlzQnVpbHRJbihuYW1lLCBzZXR0aW5ncywgcGF0aCkpIHsgcmV0dXJuICdidWlsdGluJzsgfVxuICBpZiAoaXNSZWxhdGl2ZVRvUGFyZW50KG5hbWUsIHNldHRpbmdzLCBwYXRoKSkgeyByZXR1cm4gJ3BhcmVudCc7IH1cbiAgaWYgKGlzSW5kZXgobmFtZSwgc2V0dGluZ3MsIHBhdGgpKSB7IHJldHVybiAnaW5kZXgnOyB9XG4gIGlmIChpc1JlbGF0aXZlVG9TaWJsaW5nKG5hbWUsIHNldHRpbmdzLCBwYXRoKSkgeyByZXR1cm4gJ3NpYmxpbmcnOyB9XG4gIGlmIChpc0V4dGVybmFsUGF0aChwYXRoLCBjb250ZXh0KSkgeyByZXR1cm4gJ2V4dGVybmFsJzsgfVxuICBpZiAoaXNJbnRlcm5hbFBhdGgocGF0aCwgY29udGV4dCkpIHsgcmV0dXJuICdpbnRlcm5hbCc7IH1cbiAgaWYgKGlzRXh0ZXJuYWxMb29raW5nTmFtZShuYW1lKSkgeyByZXR1cm4gJ2V4dGVybmFsJzsgfVxuICByZXR1cm4gJ3Vua25vd24nO1xufVxuXG5leHBvcnQgZGVmYXVsdCBmdW5jdGlvbiByZXNvbHZlSW1wb3J0VHlwZShuYW1lLCBjb250ZXh0KSB7XG4gIHJldHVybiB0eXBlVGVzdChuYW1lLCBjb250ZXh0LCByZXNvbHZlKG5hbWUsIGNvbnRleHQpKTtcbn1cbiJdfQ==